namespace Univent.Application.Exceptions
{
    public class UserProfileCreationFailedException : ApplicationException
    {
        public UserProfileCreationFailedException()
            : base($"Unable to create a new user profile.")
        {

        }
    }
}
