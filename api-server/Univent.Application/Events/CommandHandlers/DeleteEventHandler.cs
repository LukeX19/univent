using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.CommandHandlers
{
    internal class DeleteEventHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteEventHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(Event), request.EventID);

            _dbcontext.Events.Remove(_event);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
