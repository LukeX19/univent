using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.Universities.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.CommandHandlers
{
    internal class UpdateUniversityHandler : IRequestHandler<UpdateUniversityCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateUniversityHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            var university = await _dbcontext.Universities.FirstOrDefaultAsync(u => u.UniversityID == request.UniversityID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(University), request.UniversityID);

            university.UpdateUniversity(request.Name);

            _dbcontext.Update(university);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
