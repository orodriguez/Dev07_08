using System.Security.Claims;
using Okane.Application.Auth;

namespace Okane.WebApi;

public class HttpContextUserSession : IUserSession
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpContextUserSession(IHttpContextAccessor contextAccessor) => 
        _contextAccessor = contextAccessor;

    public int GetCurrentUserId()
    {
        var httpContext = _contextAccessor.HttpContext!;
        
        var nameIdentifierClaim = httpContext
            .User
            .FindFirst(ClaimTypes.NameIdentifier);
        
        return int.Parse(nameIdentifierClaim!.Value);
    }
}