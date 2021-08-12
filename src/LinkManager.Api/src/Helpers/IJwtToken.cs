using System.Security.Claims;

namespace LinkManager.Api.src.Helpers
{
    public interface IJwtToken
    {
         string GenerateToken(ClaimsIdentity claims);
    }
}