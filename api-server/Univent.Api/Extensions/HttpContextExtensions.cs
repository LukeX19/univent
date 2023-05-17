using System.Security.Claims;

namespace Univent.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserProfileIdClaimValue(this HttpContext context)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            return Guid.Parse(claimsIdentity?.FindFirst("UserProfileId")?.Value);
            //return GetGuidClaimValue(context, "UserProfileId");
        }

        public static string GetIdentityIdClaimValue(this HttpContext context)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            return claimsIdentity?.FindFirst("IdentityId")?.Value;
            //return GetGuidClaimValue(context, "IdentityId");
        }

        /*private static Guid GetGuidClaimValue(HttpContext context, string key)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            return Guid.Parse(claimsIdentity?.FindFirst(key)?.Value);
        }*/
    }
}
