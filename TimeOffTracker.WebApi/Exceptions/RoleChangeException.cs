using System;

namespace TimeOffTracker.WebApi
{
    public class RoleChangeException : InvalidOperationException
    {
        public RoleChangeException(string message) : base(message)
        { }
    }
}
