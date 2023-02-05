using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Dal.Configurations
{
    internal class ParticipantsConfig : IEntityTypeConfiguration<Participants>
    {
        public void Configure(EntityTypeBuilder<Participants> builder)
        {
            builder.HasNoKey();
        }
    }
}
