using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Dal.Configurations
{
    internal class EventParticipantConfig : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasKey(ep => new { ep.EventID, ep.UserID });
        }
    }
}
