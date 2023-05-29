using AutoMapper;
using Univent.Api.Contracts.Event.Requests;
using Univent.Api.Contracts.Event.Responses;
using Univent.Application.DTOs;
using Univent.Application.Events.Commands;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Api.MappingProfiles
{
    public class EventMappings : Profile
    {
        public EventMappings()
        {
            CreateMap<EventCreate, CreateEventCommand>();
            CreateMap<EventUpdate, UpdateEventCommand>();
            CreateMap<EventUpdate_CancelOption, UpdateEvent_CancelOptionCommand>();
            CreateMap<Event, EventResponse>();
            CreateMap<EventReadModel, EventResponse>();
        }
    }
}
