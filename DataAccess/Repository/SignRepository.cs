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
    public class SignRepository:BaseRepository<Sign>
    {
        public SignRepository(VacationsContext context) : base(context) { }
        public override async Task<IReadOnlyCollection<Sign>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public override async Task<IReadOnlyCollection<Sign>> FindAllByConditionAsync(Expression<Func<Sign, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync();
        }

        public override async Task<Sign> FindByConditionAsync(Expression<Func<Sign, bool>> predicat)
        {
            return await this.Entities.Where(predicat).FirstOrDefaultAsync();
        }
    }
}
