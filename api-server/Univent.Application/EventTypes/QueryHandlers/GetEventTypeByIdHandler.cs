using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventTypes.Queries;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.QueryHandlers
{
    internal class GetEventTypeByIdHandler : IRequestHandler<GetEventTypeById, EventType>
    {
        private readonly DataContext _dbcontext;

        public GetEventTypeByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EventType> Handle(GetEventTypeById request, CancellationToken cancellationToken)
        {
            var eventType = await _dbcontext.EventTypes.FirstOrDefaultAsync(et => et.EventTypeID == request.EventTypeID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(EventType), request.EventTypeID);

            return eventType;
        }
    }
}
