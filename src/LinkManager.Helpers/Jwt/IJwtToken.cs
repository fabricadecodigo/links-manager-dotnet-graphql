using System.Security.Claims;

namespace LinkManager.Helpers.Jwt
{
    public interface IJwtToken
    {
         string GenerateToken(ClaimsIdentity claims);
    }
}