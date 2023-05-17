using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetEventsByUserIdHandler : IRequestHandler<GetEventsByUserId, IEnumerable<Event>>
    {
        private readonly DataContext _dbcontext;

        public GetEventsByUserIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Event>> Handle(GetEventsByUserId request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Events
                .Where(e => e.UserProfileID == request.UserProfileID)
                .ToListAsync(cancellationToken);
        }
    }
}
