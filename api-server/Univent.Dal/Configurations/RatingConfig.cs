using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Dal.Configurations
{
    internal class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(r => r.UserProfile)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserProfileID);
        }
    }
}
