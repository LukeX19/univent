using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.EventParticipant.Requests;
using Univent.Api.Contracts.EventParticipant.Responses;
using Univent.Application.EventParticipants.Commands;
using Univent.Application.EventParticipants.Queries;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class EventParticipantController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventParticipantController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventParticipants()
        {
            var query = new GetAllEventParticipants();
            var response = await _mediator.Send(query);
            var eventParticipants = _mapper.Map<List<EventParticipantResponse>>(response);

            return Ok(eventParticipants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventParticipant(EventParticipantCreate evParticipant)
        {
            var command = _mapper.Map<CreateEventParticipantCommand>(evParticipant);
            var response = await _mediator.Send(command);
            var eventParticipant = _mapper.Map<EventParticipantResponse>(response);

            return CreatedAtAction(nameof(GetEventParticipantByBothIds),
                new { id_event = response.EventID, id_participant = response.UserProfileID }, eventParticipant);
        }

        [HttpGet]
        [Route(ApiRoutes.EventParticipant.BothIdsRoute)]
        public async Task<IActionResult> GetEventParticipantByBothIds(Guid id_event, Guid id_participant)
        {
            var query = new GetEventParticipantByBothIds
            {
                EventID = id_event,
                UserProfileID = id_participant
            };
            var response = await _mediator.Send(query);
            var evParticipant = _mapper.Map<EventParticipantResponse>(response);

            return Ok(evParticipant);
        }

        [HttpGet]
        [Route(ApiRoutes.EventParticipant.EventIdRoute)]
        public async Task<IActionResult> GetEventParticipantsByEventId(Guid id_event)
        {
            var query = new GetEventParticipantsByEventId { EventID = id_event };
            var response = await _mediator.Send(query);
            var eventParticipants = _mapper.Map<List<EventParticipantResponse>>(response);

            return Ok(eventParticipants);
        }

        [HttpGet]
        [Route(ApiRoutes.EventParticipant.UserProfileIdRoute)]
        public async Task<IActionResult> GetEventsByParticipantId(Guid id_participant)
        {
            var query = new GetEventsByParticipantId { UserProfileID= id_participant };
            var response = await _mediator.Send(query);
            var eventsForUser = _mapper.Map<List<EventParticipantResponse>>(response);

            return Ok(eventsForUser);
        }

        [HttpDelete]
        [Route(ApiRoutes.EventParticipant.BothIdsRoute)]
        public async Task<IActionResult> DeleteEventParticipant(Guid id_event, Guid id_participant)
        {
            var command = new DeleteEventParticipantCommand
            {
                EventID = id_event,
                UserProfileID = id_participant
            };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
