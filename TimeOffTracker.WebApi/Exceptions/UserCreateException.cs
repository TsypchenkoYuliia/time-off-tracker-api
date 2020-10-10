using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOffTracker.WebApi.Exceptions
{
    public class UserCreateException : Exception
    {
        public UserCreateException(string message) : base(message)
        { }
    }
}
