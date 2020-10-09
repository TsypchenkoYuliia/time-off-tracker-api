using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Requests = new List<TimeOffRequest>();
        }
        public string Position { get; set; }
        public ICollection<TimeOffRequest> Requests { get; set; }
    }
}
