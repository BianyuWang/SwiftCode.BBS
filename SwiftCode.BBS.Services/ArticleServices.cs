using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IRepositories.Base;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model.Models;

using SwiftCode.BBS.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Services
{
    public class ArticleServices : BaseServices<Article>,IArticleService
    {
     
        //private readonly IArticleRepository _articleRepository;
        //public ArticleServices(IBaseRepository<Article> baseRepository, IArticleRepository articleRepository) : base(baseRepository)
        //{
        //    _articleRepository = articleRepository;
        //}

        ////private IArticleRepository _articleRepository;

        //public ArticleService()
        //{
        //    _articleRepository = new IArticleRepository();
        //}
        //private  IArticleRepository _articleRepository;

        //public ArticleService()
        //{
        //    _articleRepository = new ArticleRepository();
        //}

        //public ArticleService(IBaseRepository<Article> baseRepository, IArticleRepository articleRepository) : base(baseRepository)
        //{
        //    _articleRepository = articleRepository;
        //}


    }
}
