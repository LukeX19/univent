namespace Univent.Application.Exceptions
{
    public class IdentityUserAlreadyExistsException : ApplicationException
    {
        public IdentityUserAlreadyExistsException(string email)
            : base($"Identity user with email {email} already exists. Cannot register a new user.")
        {

        }
    }
}
