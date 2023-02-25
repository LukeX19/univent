using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Dal.Configurations
{
    internal class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(e => e.EventType)
                .WithMany(et => et.Events)
                .HasForeignKey(e => e.EventTypeID);

            builder.HasOne(e => e.UserHost)
                .WithMany(up => up.CreatedEvents)
                .HasForeignKey(e => e.UserProfileID);
        }
    }
}
