using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF_Models
{
    public class User//:IdentityUser
    {
        public Guid Id { get; set; } //remove after adding Identity
        public User()
        {
            Applications = new List<Application>();
            Signs = new List<Sign>();
        }
        public string Position { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<Sign> Signs { get; set; }
    }
}
