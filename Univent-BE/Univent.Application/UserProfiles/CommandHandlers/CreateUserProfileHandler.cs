using MediatR;
using Univent.Application.Models;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class CreateUserProfileHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public CreateUserProfileHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress, 
                request.PhoneNumber, request.DateOfBirth, request.Hometown);
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInformation);

            _dbcontext.UserProfiles.Add(userProfile);
            await _dbcontext.SaveChangesAsync();

            //IsError is false by default
            //result.IsError = false;
            result.Payload = userProfile;

            return result;
        }
    }
}
