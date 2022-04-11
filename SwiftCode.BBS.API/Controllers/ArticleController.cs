using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Extensions;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Services;
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
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }



        /// <summary>
        /// get article by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = "Get")]
        public async Task<Article> Get(int id)
        {
          //  IArticleService artileService = new ArticleServices();
            return await _articleService.GetAsync(a => a.Id == id);

        }
    }
}
