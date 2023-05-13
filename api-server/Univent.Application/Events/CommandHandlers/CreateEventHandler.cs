using MediatR;
using Univent.Application.Events.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.CommandHandlers
{
    internal class CreateEventHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly DataContext _dbcontext;

        public CreateEventHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = Event.CreateEvent(request.UserProfileID, request.EventTypeID, request.Name, request.Description,
                request.MaximumParticipants, request.StartTime, request.EndTime, request.LocationLat, request.LocationLng);
        
            _dbcontext.Events.Add(_event);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return _event;
        }
    }
}
