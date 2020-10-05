using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class TimeOffTrackerContext:DbContext
    {
        public TimeOffTrackerContext(DbContextOptions<TimeOffTrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TimeOffRequest> TimeOffRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TimeOffRequestReview> TimeOffRequestReviews { get; set; }
    }
}
