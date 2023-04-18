using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetAllEventsHandler : IRequestHandler<GetAllEvents, IEnumerable<Event>>
    {
        private readonly DataContext _dbcontext;

        public GetAllEventsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Event>> Handle(GetAllEvents request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Events.ToListAsync(cancellationToken);
        }
    }
}
