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
    public class TimeOffRequestReviewRepository : IRepository<TimeOffRequestReview>
    {
        private TimeOffTrackerContext _context { get; set; }
        public TimeOffRequestReviewRepository(TimeOffTrackerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TimeOffRequestReview entity)
        {
            await _context.TimeOffRequestReviews.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.TimeOffRequestReviews.Remove(await _context.TimeOffRequestReviews.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TimeOffRequestReview>> FilterAsync(Expression<Func<TimeOffRequestReview, bool>> predicate)
        {
            return await _context.TimeOffRequestReviews.Where(predicate).ToListAsync();
        }

        public async Task<TimeOffRequestReview> FindAsync(Expression<Func<TimeOffRequestReview, bool>> predicate)
        {
            return await _context.TimeOffRequestReviews.FirstOrDefaultAsync(predicate);
        }

        public async Task<TimeOffRequestReview> FindAsync(Guid id)
        {
            return await _context.TimeOffRequestReviews.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<TimeOffRequestReview>> GetAllAsync()
        {
            return await _context.TimeOffRequestReviews.ToListAsync();
        }
    }
}
