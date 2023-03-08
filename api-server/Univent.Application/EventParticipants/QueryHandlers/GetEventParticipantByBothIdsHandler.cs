using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetEventParticipantByBothIdsHandler : IRequestHandler<GetEventParticipantByBothIds, EventParticipant>
    {
        private readonly DataContext _dbcontext;

        public GetEventParticipantByBothIdsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EventParticipant> Handle(GetEventParticipantByBothIds request, CancellationToken cancellationToken)
        {
            return await _dbcontext.EventParticipants.FirstOrDefaultAsync(ep => ep.EventID == request.EventID
            && ep.UserProfileID == request.UserProfileID);
        }
    }
}
