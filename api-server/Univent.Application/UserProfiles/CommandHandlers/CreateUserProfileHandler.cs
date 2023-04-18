using MediatR;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class CreateUserProfileHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _dbcontext;

        public CreateUserProfileHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress, 
                request.PhoneNumber, request.DateOfBirth, request.Hometown);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), request.UniversityID, request.Year, basicInformation);


            _dbcontext.UserProfiles.Add(userProfile);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return userProfile;
        }
    }
}
