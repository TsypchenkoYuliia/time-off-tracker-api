using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class Sign
    {
        public Guid Id { get; set; }
        public User Manager { get; set; }
        public int UserId { get; set; }
        public bool Approved { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
    }
}
