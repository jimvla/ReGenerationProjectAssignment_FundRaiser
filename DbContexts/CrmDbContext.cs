using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.DbContexts
{
    public class CrmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status_Update> Status_Updates { get; set; }
        public DbSet<Funding_Package> Funding_Packages { get; set; }
        public DbSet<Project_Tracker> Project_Tracker { get; set; }
        public DbSet<Category> Category { get; set; }

        public CrmDbContext() { }
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
        }

    }
}
