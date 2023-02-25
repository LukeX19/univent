using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Enums;
using Univent.Application.Models;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;
using Univent.Domain.Exceptions;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInformationHandler : IRequestHandler<UpdateUserProfileBasicInformationCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public UpdateUserProfileBasicInformationHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInformationCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _dbcontext.UserProfiles
                    .FirstOrDefaultAsync(up => up.UserID == request.UserProfileID);

                if(userProfile is null)
                {
                    result.IsError = true;
                    var error = new Error
                    {
                        Code = ErrorCodeEnum.NotFound,
                        Message = $"No User Profile was found with ID {request.UserProfileID}!"
                    };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress,
                    request.PhoneNumber, request.DateOfBirth, request.Hometown);

                userProfile.UpdateBasicInformation(basicInformation);

                _dbcontext.UserProfiles.Update(userProfile);
                await _dbcontext.SaveChangesAsync();

                result.Payload = userProfile;
                return result;
            }
            catch (UserProfileNotValidException ex)
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
            catch (Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCodeEnum.ServerError,
                    Message = e.Message
                };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}
