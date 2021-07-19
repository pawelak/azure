using csCodeSampleApi.Models;
using Microsoft.EntityFrameworkCore;
using vsCodeSampleApi.Models;

namespace vsCodeSampleApi.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options): base(options){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestUser>().Property(x => x.Name).HasMaxLength(100);
            builder.Entity<TestRole>().Property(x => x.Name).HasMaxLength(100);


            builder.Entity<TestUser>().ToTable("TestUser");
            builder.Entity<TestRole>().ToTable("TestRole");
        }

        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<TestRole> TestRoles { get; set; }

    }
}