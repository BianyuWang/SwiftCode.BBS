using AutoMapper;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AutoMapper
{// This is the approach starting with version 5,----profile
    public class QuestionProfile: Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionInputDto, Question>();
            CreateMap<UpdateQuestionInputDto, Question>();

            CreateMap<Question, QuestionDto>()
                .ForMember(dest=>dest.QuestionCommentCount,opts=>opts.MapFrom(src=>src.QuestionComments.Count))
         ;

            CreateMap<QuestionComment, QuestionCommentDto>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.CreateUser.UserName))
                .ForMember(dest => dest.Avatar, opts => opts.MapFrom(src => src.CreateUser.Avatar));

            CreateMap<CreateQuestionCommentsInputDto, QuestionComment>();



            
        }
    }
}
