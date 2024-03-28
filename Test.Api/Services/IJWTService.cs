using Test.Api.Constants;

namespace Test.Api.Services;

public interface IJWTService
{
    string GenerateToken(JwtConst calims);
    JwtConst? Authenticate (HttpContext httpContext);
}