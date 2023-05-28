using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.CommandHandlers
{
    internal class UpdateEventParticipant_SetFeedbackHandler : IRequestHandler<UpdateEventParticipant_SetFeedbackCommand>
    {
        private readonly DataContext _dbcontext;

        public UpdateEventParticipant_SetFeedbackHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateEventParticipant_SetFeedbackCommand request, CancellationToken cancellationToken)
        {
            var _eventParticipant = await _dbcontext.EventParticipants.FirstOrDefaultAsync(ep => ep.EventID == request.EventID && ep.UserProfileID == request.UserProfileID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(EventParticipant), request.EventID, request.UserProfileID);

            _eventParticipant.UserProvidedFeedback();

            _dbcontext.Update(_eventParticipant);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
