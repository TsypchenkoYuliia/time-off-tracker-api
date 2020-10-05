using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class User//:IdentityUser
    {
        public int Id { get; set; } //remove after adding Identity
        public User()
        {
            Requests = new List<TimeOffRequest>();
        }
        public string Position { get; set; }
        public ICollection<TimeOffRequest> Requests { get; set; }
    }
}
