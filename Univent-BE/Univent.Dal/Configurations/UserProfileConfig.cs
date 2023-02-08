using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Dal.Configurations
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(userProfile => userProfile.UserID);
            builder.OwnsOne(userProfile => userProfile.BasicInfo);
        }
    }
}
