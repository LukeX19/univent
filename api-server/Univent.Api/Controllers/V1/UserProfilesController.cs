using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.UserProfile.Requests;
using Univent.Api.Contracts.UserProfile.Responses;
using Univent.Application.UserProfiles.Commands;
using Univent.Application.UserProfiles.Queries;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserProfilesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);

            return Ok(profiles);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(Guid id)
        {
            var query = new GetUserProfileById { UserProfileID = id };
            var response = await _mediator.Send(query);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return Ok(userProfile);
        }

        //chose HttpPatch because we update only a part of the resource, not the whole resource
        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(Guid id, UserProfileCreateUpdate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInformationCommand>(updatedProfile);
            command.UserProfileID = id;
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(Guid id)
        {
            var command = new DeleteUserProfileCommand { UserProfileID = id };
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.Unnaproved)]
        public async Task<IActionResult> GetUnapprovedProfiles()
        {
            var query = new GetUnapprovedUserProfiles();
            var response = await _mediator.Send(query);
            var profiles = _mapper.Map<List<UserProfileResponse>>(response);

            return Ok(profiles);
        }
    }
}
