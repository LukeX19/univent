using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univent.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        public Guid UserID { get; private set; }
        //foreign key to Identity User (will be Identity object from Microsoft ASP.NET Identity)
        public string IdentityID { get; private set; }
        public BasicInformation BasicInfo { get; private set; }
        public DateTime CreatedDate { get; private set; }

        //Constructor
        private UserProfile()
        {
        }

        //Factory method
        public static UserProfile CreateUserProfile(string identityID, BasicInformation basicInfo)
        {
            //TO DO: add validation and error handling

            var userProfile = new UserProfile
            {
                IdentityID = identityID,
                BasicInfo = basicInfo,
                CreatedDate = DateTime.UtcNow
            };

            return userProfile;
        }

        //Public methods start here
        public void UpdateBasicInformation(BasicInformation newInformation)
        {
            BasicInfo= newInformation;
        }
    }
}
