using SwiftCode.BBS.IServices.Base;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IServices
{
    public interface IArticleService : IBaseServeces<Article>
    {
        //void Add(Article model);
        //void Delete(Article model);
        //void Update(Article model);
        //List<Article> Query(Expression<Func<Article,bool>> whereExpression);
        Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Article> GetArticleDetailsAsync(int id, CancellationToken cancellationToken = default);

    }
}
