using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetAvailableEventsHandler : IRequestHandler<GetAvailableEvents, IEnumerable<Event>>
    {
        private readonly DataContext _dbcontext;

        public GetAvailableEventsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Event>> Handle(GetAvailableEvents request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Events
                .Where(e => e.EndTime > DateTime.Now && e.IsCancelled == false)
                .ToListAsync(cancellationToken);
        }
    }
}
