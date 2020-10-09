using Domain.EF_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class TimeOffTrackerContext:IdentityDbContext<User>
    {
        public TimeOffTrackerContext(DbContextOptions<TimeOffTrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TimeOffRequest> TimeOffRequests { get; set; }
        public DbSet<TimeOffRequestReview> TimeOffRequestReviews { get; set; }
    }
}
