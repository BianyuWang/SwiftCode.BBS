using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Services
{
    public class ArticleService : IArticleService
    {
        public ArticalRepository articalRepository;

        public ArticleService()
        {
            articalRepository = new ArticalRepository();
        }
        public void Add(Article model)
        {
            articalRepository.Add(model);
        }

        public void Delete(Article model)
        {
            articalRepository.Delete(model);
        }

        public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        {
          return  articalRepository.Query(whereExpression);
        }

        public void Update(Article model)
        {
            articalRepository.Update(model);
        }
    }
}
