using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Enums;
using Univent.Application.Models;
using Univent.Application.UserProfiles.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, OperationResult<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public GetUserProfileByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var profile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID);

            if(profile is null)
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

            result.Payload = profile;
            return result;
        }
    }
}
