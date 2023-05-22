using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInformationHandler : IRequestHandler<UpdateUserProfileBasicInformationCommand>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public UpdateUserProfileBasicInformationHandler(DataContext dbcontext, UserManager<IdentityUser> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UpdateUserProfileBasicInformationCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(UserProfile), request.UserProfileID);

            var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress,
                request.PhoneNumber, request.DateOfBirth, request.Hometown, request.ProfilePicture);

            var identityUser = await _userManager.FindByEmailAsync(userProfile.BasicInfo.EmailAddress);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException(userProfile.BasicInfo.EmailAddress);
            }

            userProfile.UpdateBasicInformation(basicInformation);
            userProfile.UpdateUniversityInformation(request.UniversityID, request.Year);

            _dbcontext.UserProfiles.Update(userProfile);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            identityUser.UserName = request.EmailAddress;
            identityUser.Email = request.EmailAddress;
            await _userManager.UpdateAsync(identityUser);

            return new Unit();
        }
    }
}
