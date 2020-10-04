using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Models
{
    public class TimeOffRequestReviewApiModels
    {
        public Guid Id { get; set; }
        public UserApiModels Reviewer { get; set; }
        public int ReviewerId { get; set; }
        public bool IsApproved { get; set; }
        public TimeOffRequestApiModels Application { get; set; }
        public int ApplicationId { get; set; }
    }
}
