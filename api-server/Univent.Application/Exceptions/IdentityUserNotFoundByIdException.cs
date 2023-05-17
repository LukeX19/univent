namespace Univent.Application.Exceptions
{
    public class IdentityUserNotFoundByIdException : ApplicationException
    {
        public IdentityUserNotFoundByIdException(string id)
            : base($"Identity user with id {id} does not exist.")
        {

        }
    }
}
