using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Domain.Aggregates.UserAggregate
{
    public class UserProfile
    {
        public Guid UserID { get; private set; }
        //foreign key to Identity User (will be Identity object from Microsoft ASP.NET Identity)
        public string IdentityID { get; private set; }
        public BasicInformation BasicInfo { get; private set; }
        public DateTime CreatedDate { get; private set; }
        private readonly List<Event> _events = new List<Event>();
        public IEnumerable<Event> CreatedEvents { get { return _events; } }

        //Constructor
        private UserProfile()
        {
        }

        //Factory method
        public static UserProfile CreateUserProfile(string identityID, BasicInformation basicInfo)
        {
            //TO DO: add validation and error handling
            var newUserProfile = new UserProfile
            {
                IdentityID = identityID,
                BasicInfo = basicInfo,
                CreatedDate = DateTime.UtcNow
            };

            return newUserProfile;
        }

        //Public methods start here
        public void UpdateBasicInformation(BasicInformation newInformation)
        {
            BasicInfo = newInformation;
        }
    }
}
