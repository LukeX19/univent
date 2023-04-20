using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Univent.Application.Exceptions;
using Univent.Application.Identity.Commands;
using Univent.Application.Options;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;
//using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Univent.Application.Identity.CommandHandlers
{
    public class RegisterIdentityHandler : IRequestHandler<RegisterIdentityCommand, string>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public RegisterIdentityHandler(DataContext dbcontext, UserManager<IdentityUser> userManager, IOptions<JwtSettings> jwtSettings)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Handle(RegisterIdentityCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.Username);
            if(identityUser != null)
            {
                throw new IdentityUserAlreadyExistsException(request.Username);
            }

            var identity = new IdentityUser
            {
                Email = request.Username,
                UserName = request.Username,
            };

            //using a transaction because for the following operations have to happen together
            //if one fails, none of the operations should happen
            using var transaction = _dbcontext.Database.BeginTransaction();
            var createdIdentity = await _userManager.CreateAsync(identity, request.Password);
            if (!createdIdentity.Succeeded)
            {
                await transaction.RollbackAsync();
                throw new IdentityCreationFailedException();
            }

            var profileInfo = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.Username,
    request.PhoneNumber, request.DateOfBirth, request.Hometown);
            var userProfile = UserProfile.CreateUserProfile(identity.Id, request.UniversityID, request.Year, profileInfo);
            
            try
            {
                _dbcontext.UserProfiles.Add(userProfile);

                await _dbcontext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw new UserProfileCreationFailedException();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, identity.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, identity.Email),
                    new Claim("IdentityId", identity.Id),
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
