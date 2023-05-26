namespace Univent.Application.Exceptions
{
    public class UnapprovedUserException : ApplicationException
    {
        public UnapprovedUserException(string email)
            : base($"User with email {email} has not been approved by the administrator yet.")
        {

        }
    }
}
