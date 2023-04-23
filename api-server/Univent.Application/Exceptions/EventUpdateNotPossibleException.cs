namespace Univent.Application.Exceptions
{
    public class EventUpdateNotPossibleException : ApplicationException
    {
        public EventUpdateNotPossibleException()
            : base($"Cannot update event because this is not the owner (the given user id is different).")
        {

        }
    }
}
