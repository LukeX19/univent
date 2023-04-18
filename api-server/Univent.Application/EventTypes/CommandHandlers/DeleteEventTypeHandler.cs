using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventTypes.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.CommandHandlers
{
    internal class DeleteEventTypeHandler : IRequestHandler<DeleteEventTypeCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteEventTypeHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteEventTypeCommand request, CancellationToken cancellationToken)
        {
            var eventType = await _dbcontext.EventTypes.FirstOrDefaultAsync(et => et.EventTypeID == request.EventTypeID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(EventType), request.EventTypeID);

            _dbcontext.EventTypes.Remove(eventType);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
