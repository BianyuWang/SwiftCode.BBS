using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    {/// <summary>
    /// get article by id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public List<Article> Get(int id)
        {
            IArticleService artileService = new ArticleService();
          return  artileService.Query(d => d.Id == id);

        }
    }
}
