namespace Univent.Application.Exceptions
{
    public class IdentityCreationFailedException : ApplicationException
    {
        public IdentityCreationFailedException()
            : base($"Unable to create a new Identity.")
        {

        }
    }
}
