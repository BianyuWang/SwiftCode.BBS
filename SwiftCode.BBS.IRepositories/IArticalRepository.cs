using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IRepositories
{
  public  interface IArticalRepository
    {
        void Add(Article model);
        void Delete(Article model);
        void Update(Article model);
        List<Article> Query(Expression<Func<Article, bool>> whereExpression);
    }
}
