using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Models
{
    public class UserApiModel
    {
        public int Id { get; set; } 
        public UserApiModel()
        {
            Requests = new List<TimeOffRequestApiModel>();
        }
        public string Position { get; set; }
        public ICollection<TimeOffRequestApiModel> Requests { get; set; }
    }
}
