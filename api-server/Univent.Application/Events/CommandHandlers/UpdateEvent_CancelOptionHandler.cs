using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.CommandHandlers
{
    internal class UpdateEvent_CancelOptionHandler : IRequestHandler<UpdateEvent_CancelOptionCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateEvent_CancelOptionHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateEvent_CancelOptionCommand request, CancellationToken cancellationToken)
        {
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(Event), request.EventID);

            if (_event.UserProfileID != request.UserProfileID)
            {
                throw new EventUpdateNotPossibleException();
            }

            _event.CancelEvent();

            _dbcontext.Update(_event);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
