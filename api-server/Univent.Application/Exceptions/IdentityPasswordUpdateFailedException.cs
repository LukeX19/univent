namespace Univent.Application.Exceptions
{
    public class IdentityPasswordUpdateFailedException : ApplicationException
    {
        public IdentityPasswordUpdateFailedException()
            : base($"Unable to update the password for this Identity.")
        {

        }
    }
}
