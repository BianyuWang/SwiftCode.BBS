using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AutoMapper
{
    public class userInfoProfile : Profile
    {
        public userInfoProfile()
        {
            CreateMap<CreateUserInfoInputDto, UserInfo>();
            CreateMap<UserInfo, UserInfoDto>();
            CreateMap<UserInfo, UserInfoDetailsDto>();
        }
    }
}
