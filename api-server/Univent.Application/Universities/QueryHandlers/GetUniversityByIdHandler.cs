using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Universities.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.QueryHandlers
{
    internal class GetUniversityByIdHandler : IRequestHandler<GetUniversityById, University>
    {
        private readonly DataContext _dbcontext;

        public GetUniversityByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<University> Handle(GetUniversityById request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Universities.FirstOrDefaultAsync(u => u.UniversityID == request.UniversityID);
        }
    }
}
