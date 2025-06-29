using System.Security.Claims;

namespace JSE.EmployeeLeaveSystem.Api.Authorization
{
    public static class UserContextExtensions
    {
        public static int GetEmployeeId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? int.Parse(claim.Value) : 0;
        }

        public static string? GetRole(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
