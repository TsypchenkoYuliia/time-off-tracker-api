using Domain.EF_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class VacationsContext:DbContext
    {
        public VacationsContext(DbContextOptions<VacationsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sign> Signs { get; set; }
    }
}
