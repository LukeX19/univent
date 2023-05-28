using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.Event.Responses;
using Univent.Api.Contracts.EventParticipant.Requests;
using Univent.Api.Contracts.EventParticipant.Responses;
using Univent.Api.Contracts.UserProfile.Responses;
using Univent.Api.Extensions;
using Univent.Application.EventParticipants.Commands;
using Univent.Application.EventParticipants.Queries;
using Univent.Application.Events.Commands;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new CreateEventParticipantCommand()
            {
                EventID = evParticipant.EventID,
                UserProfileID = userProfileId
            };
            var response = await _mediator.Send(command);
            var eventParticipant = _mapper.Map<EventParticipantResponse>(response);

            return CreatedAtAction(nameof(GetEventParticipantByBothIds),
                new { id_event = response.EventID, id_participant = response.UserProfileID }, eventParticipant);
        }

        //might not be needed
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
        public async Task<IActionResult> GetParticipantsByEventId(Guid id_event)
        {
            var query = new GetParticipantsByEventId { EventID = id_event };
            var response = await _mediator.Send(query);
            var participantsForEvent = _mapper.Map<List<UserProfileResponse>>(response);

            return Ok(participantsForEvent);
        }

        [HttpGet]
        [Route(ApiRoutes.EventParticipant.UserProfileIdRoute)]
        public async Task<IActionResult> GetEventsByParticipantId(Guid id_participant)
        {
            var query = new GetEventsByParticipantId { UserProfileID = id_participant };
            var response = await _mediator.Send(query);
            var eventsForUser = _mapper.Map<List<EventResponse>>(response);

            return Ok(eventsForUser);
        }

        [HttpPatch]
        [Route(ApiRoutes.EventParticipant.FeedbackRoute)]
        public async Task<IActionResult> MarkFeedbackSent(Guid id_event)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new UpdateEventParticipant_SetFeedbackCommand()
            {
                UserProfileID = userProfileId,
                EventID = id_event
            };
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.EventParticipant.EventIdRoute)]
        public async Task<IActionResult> DeleteEventParticipant(Guid id_event)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new DeleteEventParticipantCommand
            {
                EventID = id_event,
                UserProfileID = userProfileId
            };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
