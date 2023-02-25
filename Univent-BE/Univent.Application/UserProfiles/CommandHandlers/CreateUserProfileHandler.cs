using MediatR;
using Univent.Application.Enums;
using Univent.Application.Models;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;
using Univent.Domain.Exceptions;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    public class CreateUserProfileHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public CreateUserProfileHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
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
            catch(UserProfileNotValidException ex)
            {
                result.IsError = true;
                ex.ValidationErrors.ForEach(e =>
                {
                    var error = new Error
                    {
                        Code = ErrorCodeEnum.ValidationError,
                        Message = $"{ex.Message}"
                    };
                    result.Errors.Add(error);
                });

                return result;
            }
            catch(Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCodeEnum.UnknownError,
                    Message = $"{e.Message}"
                };
                result.IsError = true;
                result.Errors.Add(error);

                return result;
            }

        }
    }
}
