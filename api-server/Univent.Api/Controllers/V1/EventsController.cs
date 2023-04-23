using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.Event.Requests;
using Univent.Api.Contracts.Event.Responses;
using Univent.Api.Extensions;
using Univent.Application.Events.Commands;
using Univent.Application.Events.Queries;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var query = new GetAllEvents();
            var response = await _mediator.Send(query);
            var events = _mapper.Map<List<EventResponse>>(response);

            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventCreate ev)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new CreateEventCommand()
            {
                UserProfileID = userProfileId,
                EventTypeID = ev.EventTypeID,
                Name = ev.Name,
                Description = ev.Description,
                MaximumParticipants = ev.MaximumParticipants,
                StartTime = ev.StartTime,
                EndTime = ev.EndTime
            };
            var response = await _mediator.Send(command);
            var _event = _mapper.Map<EventResponse>(response);

            return CreatedAtAction(nameof(GetEventById), new { id = response.EventID }, _event);
        }

        [HttpGet]
        [Route(ApiRoutes.Events.IdRoute)]
        public async Task<IActionResult> GetEventById(string id)
        {
            var query = new GetEventById { EventID = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            var _event = _mapper.Map<EventResponse>(response);

            return Ok(_event);
        }

        [HttpPatch]
        [Route(ApiRoutes.Events.IdRoute)]
        public async Task<IActionResult> UpdateEvent(string id, EventUpdate updatedEvent)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new UpdateEventCommand()
            {
                UserProfileID = userProfileId,
                EventID = Guid.Parse(id),
                Name = updatedEvent.Name,
                Description = updatedEvent.Description,
                MaximumParticipants = updatedEvent.MaximumParticipants,
                StartTime = updatedEvent.StartTime,
                EndTime = updatedEvent.EndTime
            };
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route(ApiRoutes.Events.CancelRoute)]
        public async Task<IActionResult> CancelEvent(string id, EventUpdate_CancelOption cancelledEvent)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();

            var command = new UpdateEvent_CancelOptionCommand()
            {
                UserProfileID = userProfileId,
                EventID = Guid.Parse(id),
                CancellationReason = cancelledEvent.CancellationReason,
            };
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Events.IdRoute)]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            var userProfileId = HttpContext.GetUserProfileIdClaimValue();
            var command = new DeleteEventCommand { EventID = Guid.Parse(id), UserProfileID = userProfileId };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
