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
    public class TimeOffRequestRepository : IRepository<TimeOffRequest>
    {
        private TimeOffTrackerContext _context { get; set; }
        public TimeOffRequestRepository(TimeOffTrackerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TimeOffRequest entity)
        {
            await _context.TimeOffRequests.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.TimeOffRequests.Remove(await _context.TimeOffRequests.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TimeOffRequest>> FilterAsync(Expression<Func<TimeOffRequest, bool>> predicate)
        {
            return await _context.TimeOffRequests.Where(predicate).ToListAsync();
        }

        public async Task<TimeOffRequest> FindAsync(Expression<Func<TimeOffRequest, bool>> predicate)
        {
            return await _context.TimeOffRequests.FirstOrDefaultAsync(predicate);
        }

        public async Task<TimeOffRequest> FindAsync(Guid id)
        {
            return await _context.TimeOffRequests.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<TimeOffRequest>> GetAllAsync()
        {
            return await _context.TimeOffRequests.ToListAsync();
        }
    }
}
