using System.Security.Claims;

namespace JSE.EmployeeLeaveSystem.Api.Authorization
{
    public static class UserContextExtensions
    {
        public static int GetEmployeeId(this ClaimsPrincipal user)
        {
            var idClaim = user.Claims.FirstOrDefault(c => c.Type == "EmployeeId");
            return idClaim != null ? int.Parse(idClaim.Value) : 0;
        }

        public static string? GetRole(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value;
        }
    }
}
