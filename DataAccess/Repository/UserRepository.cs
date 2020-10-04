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
    public class UserRepository: IRepository<User>
    {
        private TimeOffTrackerContext _context { get; set; }
        public UserRepository(TimeOffTrackerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Users.Remove(await _context.Users.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> FilterAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<User> FindAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
