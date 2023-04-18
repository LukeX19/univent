using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Queries;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetEventByIdHandler : IRequestHandler<GetEventById, Event>
    {
        private readonly DataContext _dbcontext;

        public GetEventByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Event> Handle(GetEventById request, CancellationToken cancellationToken)
        {
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(Event), request.EventID);

            return _event;
        }
    }
}
