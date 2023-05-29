using MediatR;
using Univent.Application.EventTypes.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.CommandHandlers
{
    internal class CreateEventTypeHandler : IRequestHandler<CreateEventTypeCommand, EventType>
    {
        private readonly DataContext _dbcontext;

        public CreateEventTypeHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EventType> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
            var eventType = EventType.CreateEventType(request.Name, request.Picture);

            _dbcontext.EventTypes.Add(eventType);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return eventType;
        }
    }
}
