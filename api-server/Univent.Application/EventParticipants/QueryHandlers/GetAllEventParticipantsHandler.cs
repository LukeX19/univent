using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetAllEventParticipantsHandler : IRequestHandler<GetAllEventParticipants, IEnumerable<EventParticipant>>
    {
        private readonly DataContext _dbcontext;

        public GetAllEventParticipantsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<EventParticipant>> Handle(GetAllEventParticipants request, CancellationToken cancellationToken)
        {
            return await _dbcontext.EventParticipants.ToListAsync();
        }
    }
}
