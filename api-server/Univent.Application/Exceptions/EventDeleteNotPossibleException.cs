namespace Univent.Application.Exceptions
{
    public class EventDeleteNotPossibleException : ApplicationException
    {
        public EventDeleteNotPossibleException()
            : base($"Cannot delete event because this is not the owner (the given user id is different).")
        {

        }
    }
}
