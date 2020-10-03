using DataAccess.Context;
using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected VacationsContext _context;
        private DbSet<TEntity> _entities;
        protected DbSet<TEntity> Entities => this._entities ??= _context.Set<TEntity>();
        protected BaseRepository(VacationsContext context)
        {
            _context = context;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> FindAllByConditionAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync();
        }

        public virtual async Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await this.Entities.Where(predicat).FirstOrDefaultAsync();
        }

        public async Task<OperationDetails> CreateAsync(TEntity entity)
        {
            try
            {
                await this.Entities.AddAsync(entity);
                return new OperationDetails { Message = "Created" };
            }
            catch(Exception ex)
            {
                //log
                return new OperationDetails { IsError = true, Message = "Create Fatal Error" };
            }
        }
    }
}
