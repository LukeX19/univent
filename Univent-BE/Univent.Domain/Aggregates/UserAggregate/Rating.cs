namespace Univent.Domain.Aggregates.UserAggregate
{
    public class Rating
    {
        public Guid RatingID { get; private set; }
        public Guid UserProfileID { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public double Value { get; private set; }

        //Constructor
        private Rating()
        {
        }

        private static Rating CreateRating(Guid chosenUserID, double value)
        {
            //TO DO: add validation and error handling
            var newRating = new Rating
            {
                UserProfileID = chosenUserID,
                Value = value
            };

            return newRating;
        }
    }
}
