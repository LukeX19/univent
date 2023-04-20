namespace Univent.Application.Exceptions
{
    public class IdentityUserNotFoundException : ApplicationException
    {
        public IdentityUserNotFoundException(string email)
            : base($"Identity user with email {email} does not exist. Login failed.")
        {

        }
    }
}
