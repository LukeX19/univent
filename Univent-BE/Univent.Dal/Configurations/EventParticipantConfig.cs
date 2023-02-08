using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Dal.Configurations
{
    internal class EventParticipantConfig : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasKey(ep => new { ep.EventID, ep.UserID });
            builder.HasOne(ep => ep.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ep => ep.EventID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ep => ep.User)
                .WithMany(u => u.ParticipatedEvents)
                .HasForeignKey(ep => ep.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
