using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository(VacationsContext context) : base(context) { }
        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public override async Task<IReadOnlyCollection<User>> FindAllByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync();
        }

        public override async Task<User> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.Entities.Where(predicat).FirstOrDefaultAsync();
        }

    }
}
