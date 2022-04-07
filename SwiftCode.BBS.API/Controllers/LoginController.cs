using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 获取Jwt令牌
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetJwtStr(string name, string pass)
        {
            TokenModelJWT tokenModel = new TokenModelJWT
            {
                Uid = 1,
                Role = "Admin"

            };
            var jwtStr = JWTHelper.IssueJWT(tokenModel);
            var suc = true;
            return  Ok(new
            {
                success = suc,
                token = jwtStr

            });
        
        }



    }
}
