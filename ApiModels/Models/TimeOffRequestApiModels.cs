using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModels.Models
{
    public class TimeOffRequestApiModels
    {
        public TimeOffRequestApiModels()
        {
            Reviews = new List<TimeOffRequestReviewApiModels>();
        }
        public Guid Id { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<TimeOffRequestReviewApiModels> Reviews { get; set; }
        public bool HasAccountingReviewPassed { get; set; }
        public bool IsFullDay { get; set; } //(sick) Full day or not
        public string Comment { get; set; }
        public string ProjectRole { get; set; }
        public int State { get; set; }
        public int Duration { get; set; }
        public UserApiModels User { get; set; }
        public int UserId { get; set; }
    }
}
