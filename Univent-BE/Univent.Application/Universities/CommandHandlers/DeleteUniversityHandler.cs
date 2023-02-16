using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Universities.Commands;
using Univent.Dal;

namespace Univent.Application.Universities.CommandHandlers
{
    internal class DeleteUniversityHandler : IRequestHandler<DeleteUniversityCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteUniversityHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            var university = await _dbcontext.Universities.FirstOrDefaultAsync(u => u.UniversityID == request.UniversityID);

            _dbcontext.Universities.Remove(university);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
