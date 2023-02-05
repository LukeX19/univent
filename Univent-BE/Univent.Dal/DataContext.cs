using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Univent.Dal.Configurations;
using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UniversityAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Dal
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<University> Universities { get; set; }

        //Constructor, which passes to base class
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdentityUserLoginConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig());
            modelBuilder.ApplyConfiguration(new ParticipantsConfig());
        }
    }
}
