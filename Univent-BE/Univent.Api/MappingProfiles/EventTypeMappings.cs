using AutoMapper;
using Univent.Api.Contracts.EventType.Requests;
using Univent.Api.Contracts.EventType.Responses;
using Univent.Application.EventTypes.Commands;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Api.MappingProfiles
{
    public class EventTypeMappings : Profile
    {
        public EventTypeMappings()
        {
            CreateMap<EventTypeCreate, CreateEventTypeCommand>();
            CreateMap<EventTypeUpdate, UpdateEventTypeCommand>();
            CreateMap<EventType, EventTypeResponse>();
        }
    }
}
