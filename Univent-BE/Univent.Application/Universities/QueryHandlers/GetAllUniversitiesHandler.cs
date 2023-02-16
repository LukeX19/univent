using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Universities.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.QueryHandlers
{
    internal class GetAllUniversitiesHandler : IRequestHandler<GetAllUniversities, IEnumerable<University>>
    {
        private readonly DataContext _dbcontext;

        public GetAllUniversitiesHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<University>> Handle(GetAllUniversities request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Universities.ToListAsync();
        }
    }
}
