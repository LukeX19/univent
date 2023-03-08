using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Commands;
using Univent.Dal;

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
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID);
        
            _dbcontext.Events.Remove(_event);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
