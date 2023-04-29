namespace Univent.Api
{
    public static class ApiRoutes
    {
        //all controllers will have the same base route string
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";
    
        public static class UserProfiles
        {
            public const string IdRoute = "{id}";
        }

        public static class Universities
        {
            public const string IdRoute = "{id}";
        }

        public static class Ratings
        {
            public const string IdRoute = "{id}";
        }

        public static class Events
        {
            public const string IdRoute = "{id}";
            public const string CancelRoute = "{id}/cancelevent";
        }

        public static class EventTypes
        {
            public const string IdRoute = "{id}";
        }

        public static class EventParticipant
        {
            public const string BothIdsRoute = "/Event/{id_event}/Participant/{id_participant}";
            public const string EventIdRoute = "/Event/{id_event}/Participants";
            public const string UserProfileIdRoute = "/MyProfile/EnrolledEvents";
        }

        public static class Identity
        {
            public const string Login = "login";
            public const string Registration = "registration";
        }
    }
}
