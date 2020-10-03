using DataAccess.Context;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(VacationsContext context, SignRepository signRepository, UserRepository userRepository, ApplicationRepository applicationRepository)
        {
            this._context = context;
            this.signRepository = signRepository;
            this.userRepository = userRepository;
            this.applicationRepository = applicationRepository;
        }
        private VacationsContext _context { get; }
        public SignRepository signRepository { get;  }
        public UserRepository userRepository { get; }
        public ApplicationRepository applicationRepository { get; }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
               
                if (sqlException != null && sqlException.Number == 2601)
                {
                    //2601 is error number of unique index violation
                    //log
                }
            }
        }
    }
}
