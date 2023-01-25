using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.UniversityAggregate
{
    public class University
    {
        public Guid UniversityID { get; private set; }
        public ICollection<UserProfile> UserProfiles { get; private set; }
        public string Name { get; private set; }

        //Constructor
        private University()
        {
        }

        //Factory method
        public static University CreateUniversity(string name)
        {
            //TO DO: add validation and error handling
            var newUniversity = new University
            {
                Name = name
            };

            return newUniversity;
        }
    }
}
