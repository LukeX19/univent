using AutoMapper;
using Univent.Api.Contracts.Event.Requests;
using Univent.Api.Contracts.EventParticipant.Requests;
using Univent.Api.Contracts.EventParticipant.Responses;
using Univent.Application.EventParticipants.Commands;
using Univent.Application.Events.Commands;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Api.MappingProfiles
{
    public class EventParticipantMappings : Profile
    {
        public EventParticipantMappings()
        {
            CreateMap<EventParticipantCreate, CreateEventParticipantCommand>();
            CreateMap<EventParticipant, EventParticipantResponse>();
            CreateMap<EventParticipantUpdate_SetFeedback, UpdateEventParticipant_SetFeedbackCommand>();
        }
    }
}
