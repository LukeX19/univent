using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.DTOs;
using Univent.Application.Events.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.QueryHandlers
{
    internal class GetAllEventsHandler : IRequestHandler<GetAllEvents, IEnumerable<EventReadModel>>
    {
        private readonly DataContext _dbcontext;

        public GetAllEventsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<EventReadModel>> Handle(GetAllEvents request, CancellationToken cancellationToken)
        {
            // return await _dbcontext.Events.ToListAsync(cancellationToken);
            var userRatings = from user in _dbcontext.UserProfiles
                                join rating in _dbcontext.Ratings
                                on user.UserProfileID equals rating.UserProfileID
                                into userRatingLeftJoin
                                from userRating in userRatingLeftJoin.DefaultIfEmpty()

                                group userRating by new
                                {
                                    user.UserProfileID,
                                    user.BasicInfo.FirstName,
                                    user.BasicInfo.LastName,
                                    user.BasicInfo.ProfilePicture
                                } into userRatingGroup

                                select new
                                {
                                    UserProfileID = userRatingGroup.Key.UserProfileID,
                                    FirstName = userRatingGroup.Key.FirstName,
                                    LastName = userRatingGroup.Key.LastName,
                                    ProfilePicture = (string?)userRatingGroup.Key.ProfilePicture,
                                    AverageRating = userRatingGroup.Average(r => r != null ? r.Value : 0)
                                };

            var query = from @event in _dbcontext.Events
                        join user in userRatings
                        on @event.UserProfileID equals user.UserProfileID

                        join eventType in _dbcontext.EventTypes
                        on @event.EventTypeID equals eventType.EventTypeID

                        select new EventReadModel
                        {
                            EventID = @event.EventID,
                            UserProfileID = @event.UserProfileID,
                            EventTypeID = eventType.EventTypeID,
                            EventName = @event.Name,
                            MaximumParticipants = @event.MaximumParticipants,
                            StartTime = @event.StartTime,
                            EndTime = @event.EndTime,
                            CreatedDate = @event.CreatedDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            ProfilePicture = user.ProfilePicture,
                            EventTypeName = eventType.Name,
                            EventTypePicture = eventType.Picture,
                            AverageRating = user.AverageRating
                        };
            return await query.ToListAsync(cancellationToken);
        }
    }
}
