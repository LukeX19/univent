using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventTypes.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.QueryHandlers
{
    internal class GetAllEventTypesHandler : IRequestHandler<GetAllEventTypes, IEnumerable<EventType>>
    {
        private readonly DataContext _dbcontext;

        public GetAllEventTypesHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<EventType>> Handle(GetAllEventTypes request, CancellationToken cancellationToken)
        {
            return await _dbcontext.EventTypes.ToListAsync(cancellationToken);
        }
    }
}
