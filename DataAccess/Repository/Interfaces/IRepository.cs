using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<IReadOnlyCollection<TEntity>> FindAllByConditionAsync(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat);
        Task<OperationDetails> CreateAsync(TEntity entity);
    }
}
