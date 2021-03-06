using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.Repositories.Base;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace SwiftCode.BBS.Repositories
{
    public class ArticalRepository :BaseRepository<Article>, IArticleRepository
    {
        public ArticalRepository(SwiftCodeBBSContext context) : base(context)
        {
        }

        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return DbContext().Articles.Where(x => x.Id == id)
                 .Include(x => x.ArticleComments).ThenInclude(x => x.CreateUser).SingleOrDefaultAsync(cancellationToken);
        }

        public Task<Article> GetCollectionArticlesByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return DbContext().Articles.Where(x => x.Id == id)
                .Include(x => x.CollectionArticles).SingleOrDefaultAsync(cancellationToken);
        }

        //private SwiftCodeBBSContext dbcontext;

        //public ArticalRepository()
        //{
        //    dbcontext = new SwiftCodeBBSContext();
        //}
        //public void Add(Article model)
        //{
        //    dbcontext.Articles.Add(model);
        //    dbcontext.SaveChanges();
        //}

        //public void Delete(Article model)
        //{
        //    dbcontext.Articles.Remove(model);
        //    dbcontext.SaveChanges();
        //}

        //public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        //{
        //    return dbcontext.Articles.Where(whereExpression).ToList();
        //}

        //public void Update(Article model)
        //{
        //    dbcontext.Articles.Update(model);
        //    dbcontext.SaveChanges();
        //}
    }
}
