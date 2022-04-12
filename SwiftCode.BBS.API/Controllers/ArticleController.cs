using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.Extensions;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.Base;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{

 
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IBaseServeces<UserInfo> _userInfoService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IBaseServeces<UserInfo> userInfoService,IMapper mapper)
        {
            _articleService = articleService;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }


        /// <summary>
        /// Get list of articles in pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<MessageModel<List<ArticleDto>>> GetList(int page, int pageSize)
        {

            var entityList = await _articleService.GetPagedListAsync(page, pageSize, nameof(Article.CreateTime));
            var articleUserIdList = entityList.Select(a => a.CreateUserId);
            var userList = await _articleService.GetListAsync(a => articleUserIdList.Contains(a.Id));
            var respose = _mapper.Map<List<ArticleDto>>(entityList);
            if (respose.Count == 0)
            {
                return new MessageModel<List<ArticleDto>>()
                {
                    success = false,
                    msg = "get list error,no article in the list",
               
                };
            }

            foreach (var item in respose)
            {

                var user = userList.FirstOrDefault(x => x.Id == item.CreateUserId);
                item.UserName = user.CreateUser.UserName;
                item.Avatar = user.CreateUser.Avatar;                   
            
            }
            return new MessageModel<List<ArticleDto>>()
            {
                success = true,
                msg = "get list successfully",
                response = respose
            };
        }


        /// <summary>
        /// get article by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = "Get")]
        public async Task<MessageModel<ArticleDetailsDto>> Get(int id)
        {
            var entity = await _articleService.GetArticleDetailsAsync(id);
            var result = _mapper.Map<ArticleDetailsDto>(entity);

            //  IArticleService artileService = new ArticleServices();
            return new MessageModel<ArticleDetailsDto>()
            {
                success = true,
                msg = "Get success",
                response = result
            };

        }

        [HttpPost]
        public async Task<MessageModel<string>> CreateAsunc(CreateArticleInputDto ArticleInput)
        {
            var token = JWTHelper.ParsingJwtToken(HttpContext);
            var entity = _mapper.Map<Article>(ArticleInput);
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId =(int) token.Uid;
            await _articleService.InsertAsync(entity, true);


            return new MessageModel<string>()
            {
                success = true,
                msg = "Create success",
              //  response = result
            };

        }
    }
}
