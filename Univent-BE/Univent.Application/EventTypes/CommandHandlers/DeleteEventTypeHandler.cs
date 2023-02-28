using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventTypes.Commands;
using Univent.Dal;

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
            var eventType = await _dbcontext.EventTypes.FirstOrDefaultAsync(et => et.EventTypeID == request.EventTypeID);
        
            _dbcontext.EventTypes.Remove(eventType);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
