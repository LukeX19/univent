namespace Univent.Api
{
    public class ApiRoutes
    {
        //all controllers will have the same base route string
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";
    
        public class UserProfiles
        {
            public const string IdRoute = "{id}";
        }

        public class Universities
        {
            public const string IdRoute = "{id}";
        }

        public class Events
        {
            public const string GetById = "{id}";
        }
    }
}
