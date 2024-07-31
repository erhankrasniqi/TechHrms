using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AppDbContext _dbContext;

        protected BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<TEntity> SetContext()
        {
            return _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return SetContext().AsEnumerable();
            }

            return SetContext().Where(predicate).AsEnumerable();
        }

        public async Task<TEntity> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await SetContext().SingleOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await SetContext().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        }

        public void Update(TEntity entity)
        {
            SetContext().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            SetContext().Remove(entity);
        }
    }
}
