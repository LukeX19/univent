using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Domain.Aggregates.UserAggregate
{
    public class UserProfile
    {
        public Guid UserProfileID { get; private set; }
        public Guid UniversityID { get; private set; }
        public string IdentityID { get; private set; }
        public University University { get; private set; }
        public UniversityYear Year { get; private set; }

        private readonly List<Event> _createdEvents = new List<Event>();
        public IEnumerable<Event> CreatedEvents { get { return _createdEvents; } }

        private readonly List<EventParticipant> _participatedEvents = new List<EventParticipant>();
        public IEnumerable<EventParticipant> ParticipatedEvents { get { return _participatedEvents; } }

        private readonly List<Rating> _ratings = new List<Rating>();
        public IEnumerable<Rating> Ratings { get { return _ratings; } }

        public BasicInformation BasicInfo { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public bool isAccountConfirmed { get; private set; }

        //Constructor
        private UserProfile()
        {
        }

        //Factory method
        public static UserProfile CreateUserProfile(string identityID, Guid universityID, UniversityYear year, BasicInformation basicInfo)
        {
            var newUserProfile = new UserProfile
            {
                IdentityID = identityID,
                UniversityID = universityID,
                Year = year,
                BasicInfo = basicInfo,
                CreatedDate = DateTime.UtcNow,
                isAccountConfirmed = false
            };

            return newUserProfile;
        }

        //Public methods start here
        public void UpdateBasicInformation(BasicInformation newInformation)
        {
            BasicInfo = newInformation;
        }

        public void UpdateUniversityInformation(Guid universityID, UniversityYear year)
        {
            UniversityID = universityID;
            Year = year;
        }

        public void ApproveUser()
        {
            isAccountConfirmed = true;
        }
    }
}
