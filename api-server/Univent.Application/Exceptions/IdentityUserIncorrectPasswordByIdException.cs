namespace Univent.Application.Exceptions
{
    public class IdentityUserIncorrectPasswordByIdException : ApplicationException
    {
        public IdentityUserIncorrectPasswordByIdException(string id)
            : base($"The provided password for identity user with id {id} is wrong.")
        {

        }
    }
}
