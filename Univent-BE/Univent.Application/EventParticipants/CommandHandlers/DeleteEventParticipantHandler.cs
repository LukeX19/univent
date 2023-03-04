using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Commands;
using Univent.Dal;

namespace Univent.Application.EventParticipants.CommandHandlers
{
    internal class DeleteEventParticipantHandler : IRequestHandler<DeleteEventParticipantCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteEventParticipantHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var eventParticipant = await _dbcontext.EventParticipants.FirstOrDefaultAsync(ep => ep.EventID == request.EventID 
            && ep.UserProfileID == request.UserProfileID);

            _dbcontext.EventParticipants.Remove(eventParticipant);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
