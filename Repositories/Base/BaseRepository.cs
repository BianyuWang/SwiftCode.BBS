using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace SwiftCode.BBS.Repositories.Base
{/// <summary>
/// implement IBaseRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class,new()
    {
        //dbContext

        private  SwiftCodeBBSContext _dbContext;

        public BaseRepository()
        {
            _dbContext = new SwiftCodeBBSContext();

        }
        
        protected SwiftCodeBBSContext DbContext()
        {
            return _dbContext;
        }
        //public BaseRepository()
        //{
        //    _dbContext = new SwiftCodeBBSContext();
        //}
        //protected SwiftCodeBBSContext DbContext()
        //{
        //    _dbContext = new SwiftCodeBBSContext();
        //    return _dbContext;
        //}


        public async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var dataSet = _dbContext.Set<TEntity>();
            var entities = await dataSet.Where(predicate).ToListAsync();

            await DeleteManyAsync(entities,autoSave,cancellationToken);
          //  _dbContext.Set<TEntity>().RemoveRange(entities);
            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Where(predicate).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(predicate, cancellationToken);
            // will return 500;
            //if (entity == null)
            //{
            //    throw new Exception(nameof(TEntity) + ": no record found");
            //}

            return entity;
        }

        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().LongCountAsync(cancellationToken);
        }

        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return _dbContext.Set<TEntity>().Where(predicate).LongCountAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().ToListAsync(cancellationToken);

        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);

        }

        public Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting,
              CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToke = default)
        {
            var savedEntity = (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToke)).Entity;

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToke);
            }
            return savedEntity;
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToke = default)
        {
            var entityArray = entities.ToArray();
           await _dbContext.Set<TEntity>().AddRangeAsync(entityArray, cancellationToke);
            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToke);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToke = default)
        {
            _dbContext.Attach(entity);
            var updatedEntity = _dbContext.Update(entity).Entity;
            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToke);
            }

            return updatedEntity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToke = default)
        {
             _dbContext.Set<TEntity>().UpdateRange(entities);

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync(cancellationToke);

            }
        }
    }
}
