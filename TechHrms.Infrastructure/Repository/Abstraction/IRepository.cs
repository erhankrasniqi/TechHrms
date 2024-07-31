using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
