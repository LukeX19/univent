using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Enums;
using Univent.Application.Models;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public DeleteUserProfileHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID);

            if(userProfile is null)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCodeEnum.NotFound,
                    Message = $"No user profile was found with ID {request.UserProfileID}!"
                };
                result.Errors.Add(error);
                return result;
            }

            _dbcontext.UserProfiles.Remove(userProfile);
            await _dbcontext.SaveChangesAsync();

            result.Payload = userProfile;

            return result;
        }
    }
}
