using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Dal.Configurations
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(u => u.UserID);

            builder.OwnsOne(u => u.BasicInfo);

            builder.HasOne(u => u.University)
                .WithMany(u => u.Students)
                .HasForeignKey(u => u.UniversityID);
        }
    }
}
