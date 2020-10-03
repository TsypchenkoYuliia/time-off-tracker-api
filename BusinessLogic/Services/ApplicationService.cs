using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
