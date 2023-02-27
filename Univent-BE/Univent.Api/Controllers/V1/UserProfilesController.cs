﻿using AutoMapper;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);

            command.UniversityID = profile.UniversityID;
            command.Year = profile.Year;

            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new {id = response.UserProfileID}, userProfile);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileID = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return Ok(userProfile);
        }

        //chose HttpPatch because we update only a part of the resource, not the whole resource
        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInformationCommand>(updatedProfile);
            command.UserProfileID = Guid.Parse(id);
            var response = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileID = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
