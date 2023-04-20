using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univent.Api.Contracts.Identity;
using Univent.Application.Identity.Commands;

namespace Univent.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IdentityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Registration)]
        public async Task<IActionResult> Register(UserRegistration registration)
        {
            var command = _mapper.Map<RegisterIdentityCommand>(registration);
            var response = await _mediator.Send(command);
            var authenticationResult = new AuthenticationResult()
            {
                Token = response
            };
            return Ok(authenticationResult);
        }

        [HttpPost]
        [Route(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login(Login login)
        {
            var command = _mapper.Map<LoginCommand>(login);
            var response = await _mediator.Send(command);
            var authenticationResult = new AuthenticationResult()
            {
                Token = response
            };
            return Ok(authenticationResult);
        }
    }
}
