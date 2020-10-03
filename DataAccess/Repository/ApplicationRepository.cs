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
    public class ApplicationRepository : BaseRepository<Application>
    {
        public ApplicationRepository(VacationsContext context) : base(context) { }
      
        public override async Task<IReadOnlyCollection<Application>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public override async Task<IReadOnlyCollection<Application>> FindAllByConditionAsync(Expression<Func<Application, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync();
        }

        public override async Task<Application> FindByConditionAsync(Expression<Func<Application, bool>> predicat)
        {
            return await this.Entities.Where(predicat).FirstOrDefaultAsync();
        }
    }
}
