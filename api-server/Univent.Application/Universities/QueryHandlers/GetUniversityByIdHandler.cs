using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
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
            var university = await _dbcontext.Universities.FirstOrDefaultAsync(u => u.UniversityID == request.UniversityID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(University), request.UniversityID);

            return university;
        }
    }
}
