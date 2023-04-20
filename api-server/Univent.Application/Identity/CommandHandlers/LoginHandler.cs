using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Univent.Application.Exceptions;
using Univent.Application.Identity.Commands;
using Univent.Application.Options;
using Univent.Dal;

namespace Univent.Application.Identity.CommandHandlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public LoginHandler(DataContext dbcontext, UserManager<IdentityUser> userManager, IOptions<JwtSettings> jwtSettings)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
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

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
                    new Claim("IdentityId", identityUser.Id),
                    new Claim("UserProfileId", userProfile.UserProfileID.ToString())
                }),
                Expires = DateTime.Now.AddHours(2),
                Audience = _jwtSettings.Audiences[0],
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
