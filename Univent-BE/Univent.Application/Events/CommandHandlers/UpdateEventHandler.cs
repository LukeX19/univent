using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Commands;
using Univent.Dal;

namespace Univent.Application.Events.CommandHandlers
{
    internal class UpdateEventHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateEventHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID);
        
            _event.UpdateEvent(request.Name, request.Description, request.MaximumParticipants,
                request.StartTime, request.EndTime);

            _dbcontext.Update(_event);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
