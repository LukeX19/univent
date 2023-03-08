using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetEventByIdHandler : IRequestHandler<GetEventById, Event>
    {
        private readonly DataContext _dbcontext;

        public GetEventByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Event> Handle(GetEventById request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID);
        }
    }
}
