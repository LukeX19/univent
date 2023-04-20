namespace Univent.Application.Exceptions
{
    public class IdentityUserIncorrectPasswordException : ApplicationException
    {
        public IdentityUserIncorrectPasswordException(string email)
            : base($"The provided password for identity user with email {email} is wrong. Login failed.")
        {

        }
    }
}
