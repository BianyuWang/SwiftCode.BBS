using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Common.Helper
{
  
   public class JWTHelper
    {
        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>

        public static string IssueJWT(TokenModelJWT tokenModel) {
            string iss = Appsettings.app(new string[] { "Audience", "Issuer" });
            string aud = Appsettings.app(new string[] { "Audience", "Audience" });
            string secret = Appsettings.app(new string[] { "Audience", "Secret" });

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                 new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                  new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
                  new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(1000).ToString()),
                  new Claim(JwtRegisteredClaimNames.Iss,iss),
                    new Claim(JwtRegisteredClaimNames.Aud,aud)
            };



            claims.AddRange(tokenModel.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: iss,
                claims:claims,
                signingCredentials:creds

                );
            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>


        public static TokenModelJWT SerializeJMT(string jwtStr)
        {

            var jwtHandler = new JwtSecurityTokenHandler();
            TokenModelJWT tokenModelJWT = new TokenModelJWT();
            if (!string.IsNullOrEmpty(jwtStr) && jwtHandler.CanReadToken(jwtStr))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
                object role;
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
                tokenModelJWT = new TokenModelJWT
                {
                    Uid = Convert.ToInt64(jwtToken.Id),
                    Role = role == null ? "" : role.ToString()

                };


            }
            return tokenModelJWT;

        }
        /// <summary>
        /// 授权解析jwt
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static TokenModelJWT ParsingJwtToken(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                return null;
            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            TokenModelJWT tm = SerializeJMT(tokenHeader);
            return tm;
        }
    }





}
