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

        public ArticleServices(IArticleRepository articleRepository):base(articleRepository)
        {

        }

    }
}
