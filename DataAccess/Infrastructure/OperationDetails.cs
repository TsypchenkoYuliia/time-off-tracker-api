using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class OperationDetails
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public bool IsError { get; set; }
    }
}
