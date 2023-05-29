using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventTypes.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.CommandHandlers
{
    internal class UpdateEventTypeHandler : IRequestHandler<UpdateEventTypeCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateEventTypeHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateEventTypeCommand request, CancellationToken cancellationToken)
        {
            var eventType = await _dbcontext.EventTypes.FirstOrDefaultAsync(et => et.EventTypeID == request.EventTypeID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(EventType), request.EventTypeID);

            eventType.UpdateEventType(request.Name, request.Picture);

            _dbcontext.Update(eventType);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
