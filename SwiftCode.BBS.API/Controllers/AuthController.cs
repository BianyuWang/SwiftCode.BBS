using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IServices.Base;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using SwiftCode.BBS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBaseServeces<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public AuthController(IBaseServeces<UserInfo> userInfoService,IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<MessageModel<string>> Login(string loginName, string loginPassWord)
        {
            var jwtStr = string.Empty;
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginPassWord))
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "user name or password could not be empty!",
                };
            }
            var pass = MD5Helper.MD5Encrypt32(loginPassWord);
            var userInfo = await _userInfoService.FindAsync(u => u.LoginName.Equals(loginName) && u.LoginPassword.Equals(pass));
            if (userInfo == null)
            {

                return new MessageModel<string>()
                {
                    success = false,
                    msg = "authentication fail",
                };
            }

            jwtStr = getUserJwt(userInfo);

            return new MessageModel<string>()
            {
                success = true,
                msg = "authentication success",
                response = jwtStr
            };
        }

        [HttpPost]
        public async Task<MessageModel<string>> Register(CreateUserInfoInputDto input)
        {
            //find if user name is used
            var userInfo = await _userInfoService.FindAsync(u => u.LoginName.Equals(input.LoginName));

            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "The account with this user name already exists",
                    // response = jwtStr
                };

            }

            userInfo = await _userInfoService.FindAsync(u => u.Email.Equals(input.Email));
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "The account with this email already exists",
                    // response = jwtStr
                };


            }
            userInfo = await _userInfoService.FindAsync(u => u.Phone.Equals(input.Phone));
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "The account with Phone Number already exists",
                    // response = jwtStr
                };


            }

            userInfo = await _userInfoService.FindAsync(u => u.UserName.Equals(input.UserName));
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "The account with Phone Number already exists",
                    // response = jwtStr
                };

            }

            input.LoginPassWord = MD5Helper.MD5Encrypt32(input.LoginPassWord);
            var user = _mapper.Map<UserInfo>(input);
            user.CreateTime = DateTime.Now;
            await _userInfoService.InsertAsync(user, true);
            var jwtStr = getUserJwt(user);
            return new MessageModel<string>()
            {
                success = true,
                msg = "The user was successfully created",
                response = jwtStr
            };
        }
        private string getUserJwt(UserInfo userInfo)
        {
            var tokenModel = new TokenModelJWT { Uid = userInfo.Id, Role = "User" };
            var jwtStr = JWTHelper.IssueJWT(tokenModel);
            return jwtStr;
        }
    }
}
