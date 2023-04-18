namespace Univent.Application.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        public ObjectNotFoundException(string type, object id)
            : base($"Object of type {type} with id {id} doesn't exist.")
        {
        
        }

        public ObjectNotFoundException(string type, object id1, object id2)
            : base($"Object of type {type} with the combination of id1 {id1} and id2 {id2} doesn't exist.")
        {

        }
    }
}
