using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInformationHandler : IRequestHandler<UpdateUserProfileBasicInformationCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateUserProfileBasicInformationHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateUserProfileBasicInformationCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbcontext.UserProfiles
                .FirstOrDefaultAsync(up => up.UserID == request.UserProfileID);
            var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress,
                request.PhoneNumber, request.DateOfBirth, request.Hometown);

            userProfile.UpdateBasicInformation(basicInformation);
            userProfile.UpdateUniversityInformation(request.UniversityID, request.Year);

            _dbcontext.UserProfiles.Update(userProfile);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
