using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Models
{
    public class UserApiModels
    {
        public Guid Id { get; set; } //remove after adding Identity
        public UserApiModels()
        {
            Applications = new List<TimeOffRequestApiModels>();
            Signs = new List<TimeOffRequestReviewApiModels>();
        }
        public string Position { get; set; }
        public ICollection<TimeOffRequestApiModels> Applications { get; set; }
        public ICollection<TimeOffRequestReviewApiModels> Signs { get; set; }
    }
}
