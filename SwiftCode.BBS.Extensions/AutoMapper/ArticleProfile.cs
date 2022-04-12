using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AutoMapper
{
  public  class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            ///AutoMapper.Mapper.CreateMap<SourceClass, DestinationClass>();
            CreateMap<CreateArticleInputDto, Article>();
            CreateMap<UpdateArticleInputDto, Article>();

            CreateMap<Article, ArticleDto>();
            CreateMap<Article, ArticleDetailsDto>();


            ///AutoMapper.Mapper.CreateMap<SourceClass, DestinationClass>()
            ///  .ForMember(dest => dest.field,
            ///     opts => opts.MapFrom(src => src.Title));
            CreateMap<ArticleComment, ArticleCommentDto>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.CreateUser.UserName))
                .ForMember(dest=>dest.Avatar,opts=>opts.MapFrom(scr=>scr.CreateUser.Avatar));

            CreateMap<CreateArticleCommentsInputDto, ArticleComment>();

        }
    }
}
