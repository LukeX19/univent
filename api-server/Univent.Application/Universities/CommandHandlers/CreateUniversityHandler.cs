using MediatR;
using Univent.Application.Universities.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.CommandHandlers
{
    internal class CreateUniversityHandler : IRequestHandler<CreateUniversityCommand, University>
    {
        private readonly DataContext _dbcontext;

        public CreateUniversityHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<University> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            var university = University.CreateUniversity(request.Name);

            _dbcontext.Universities.Add(university);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return university;
        }
    }
}
