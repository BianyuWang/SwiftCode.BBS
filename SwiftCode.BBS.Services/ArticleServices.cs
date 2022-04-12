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
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Services
{
    public class ArticleServices : BaseServices<Article>,IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleServices(IBaseRepository<Article> baseRepository, IArticleRepository articleRepository) : base(baseRepository)
        {
            _articleRepository = articleRepository;
        }

        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _articleRepository.GetByIdAsync(id, cancellationToken);
        }


      public  async Task<Article> GetArticleDetailsAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _articleRepository.GetByIdAsync(id, cancellationToken);

            if (entity != null)
            {
                entity.Traffic += 1;

                await _articleRepository.UpdateAsync(entity, true, cancellationToken);
            }
            return entity;
        }
    }
}
