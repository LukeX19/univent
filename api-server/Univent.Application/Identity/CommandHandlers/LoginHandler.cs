using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Univent.Application.Exceptions;
using Univent.Application.Identity.Commands;
using Univent.Application.Services;
using Univent.Dal;

namespace Univent.Application.Identity.CommandHandlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityService _identityService;

        public LoginHandler(DataContext dbcontext, UserManager<IdentityUser> userManager, IdentityService identityService)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _identityService = identityService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.Username);
            if(identityUser == null)
            {
                throw new IdentityUserNotFoundException(request.Username);
            }

            var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.Password);
            if(!validPassword)
            {
                throw new IdentityUserIncorrectPasswordException(request.Username);
            }

            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.IdentityID == identityUser.Id);
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
                new Claim("IdentityId", identityUser.Id),
                new Claim("UserProfileId", userProfile.UserProfileID.ToString())
            });

            var token = _identityService.CreateSecurityToken(claimsIdentity);
            return _identityService.WriteToken(token);
        }
    }
}
