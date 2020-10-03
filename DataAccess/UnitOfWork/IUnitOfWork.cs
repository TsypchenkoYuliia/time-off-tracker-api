using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        SignRepository signRepository { get; }
        UserRepository userRepository { get; }
        ApplicationRepository applicationRepository { get; }
        Task SaveChangesAsync();
    }
}
