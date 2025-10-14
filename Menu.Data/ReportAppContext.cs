using Menu.Entities.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Repository
{
    public class ReportAppContext : IdentityDbContext
    {
        public DbSet<Report> reports { get; set; }

        public ReportAppContext(DbContextOptions<ReportAppContext> ctx) : base(ctx)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
