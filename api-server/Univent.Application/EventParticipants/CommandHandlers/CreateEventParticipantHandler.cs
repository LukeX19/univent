using MediatR;
using Univent.Application.EventParticipants.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.CommandHandlers
{
    internal class CreateEventParticipantHandler : IRequestHandler<CreateEventParticipantCommand, EventParticipant>
    {
        private readonly DataContext _dbcontext;

        public CreateEventParticipantHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EventParticipant> Handle(CreateEventParticipantCommand request, CancellationToken cancellationToken)
        {
            var eventParticipant = EventParticipant.CreateEventParticipant(request.EventID, request.UserProfileID);
            
            _dbcontext.EventParticipants.Add(eventParticipant);
            await _dbcontext.SaveChangesAsync();

            return eventParticipant;
        }
    }
}
