using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.EntityFramework;
namespace SwiftCode.BBS.Repositories
{
    public class ArticalRepository : IArticalRepository
    {
        private SwiftCodeBBSContext dbcontext;

        public ArticalRepository()
        {
            dbcontext = new SwiftCodeBBSContext();
        }
        public void Add(Article model)
        {
            dbcontext.Articles.Add(model);
            dbcontext.SaveChanges();
        }

        public void Delete(Article model)
        {
            dbcontext.Articles.Remove(model);
            dbcontext.SaveChanges();
        }

        public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        {
            return dbcontext.Articles.Where(whereExpression).ToList();
        }

        public void Update(Article model)
        {
            dbcontext.Articles.Update(model);
            dbcontext.SaveChanges();
        }
    }
}
