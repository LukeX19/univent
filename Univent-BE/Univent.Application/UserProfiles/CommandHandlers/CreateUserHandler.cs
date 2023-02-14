using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _dbcontext;

        public CreateUserHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInformation = BasicInformation.CreateBasicInformation(request.FirstName, request.LastName, request.EmailAddress, 
                request.PhoneNumber, request.DateOfBirth, request.Hometown);
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInformation);

            _dbcontext.UserProfiles.Add(userProfile);
            await _dbcontext.SaveChangesAsync();

            return userProfile;
        }
    }
}
