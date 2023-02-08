﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.UserProfile.Requests;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfilesController : Controller
    {
        private readonly IMediator _mediator;

        public UserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            return (IActionResult)Task.FromResult(Ok());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
        {
            return (IActionResult)Task.FromResult(Ok());
        }
    }
}
