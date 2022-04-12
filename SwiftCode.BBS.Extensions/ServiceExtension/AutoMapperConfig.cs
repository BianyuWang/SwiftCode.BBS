using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Extensions.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.ServiceExtension
{
  public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new userInfoProfile());
                cfg.AddProfile(new ArticleProfile());
                cfg.AddProfile(new QuestionProfile());
            });
        }

    }
}
