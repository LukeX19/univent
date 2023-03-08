using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univent.Application.UserProfiles.Commands;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand, BasicInformation>();
        }
    }
}
