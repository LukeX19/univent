using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Univent.Application.Exceptions;
using Univent.Application.Identity.Commands;
using Univent.Application.Services;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;
//using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Univent.Application.Identity.CommandHandlers
{
    public class RegisterIdentityHandler : IRequestHandler<RegisterIdentityCommand, string>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityService _identityService;

        public RegisterIdentityHandler(DataContext dbcontext, UserManager<IdentityUser> userManager, IdentityService identityService)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
            _identityService = identityService;
        }

        public async Task<string> Handle(RegisterIdentityCommand request, CancellationToken cancellationToken)
        {
            var existingIdentity = await _userManager.FindByEmailAsync(request.Username);
            if(existingIdentity != null)
            {
                throw new IdentityUserAlreadyExistsException(request.Username);
            }

            var identityUser = new IdentityUser
            {
                Email = request.Username,
                UserName = request.Username,
            };

            //using a transaction here because for the following operations, they have to happen together
            //if one fails, none of the operations should happen
            using var transaction = _dbcontext.Database.BeginTransaction();
            var createdIdentity = await _userManager.CreateAsync(identityUser, request.Password);
            if (!createdIdentity.Succeeded)
            {
                await transaction.RollbackAsync();
                throw new IdentityCreationFailedException();
            }

            var profileInfo = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.Username,
    request.PhoneNumber, request.DateOfBirth, request.Hometown);
            var userProfile = UserProfile.CreateUserProfile(identityUser.Id, request.UniversityID, request.Year, profileInfo);
            
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
