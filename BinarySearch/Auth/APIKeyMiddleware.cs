using EpsiVal.Api.Docs;
using EpsiVal.Api.Extensions;
using System.Security.Claims;

namespace EpsiVal.Api.Auth;

public class APIKeyMiddleware
{
    private readonly IReadOnlyList<string> AllowAnonymous = new List<string>(){ "/api/docs", "/api/docs/index.html" };
    
    private Dictionary<Guid, string> ApiKeys = new()
    {
        { Guid.Parse("84c862aa-2d81-44a4-8d21-ba3148066eac"), "ShopCircle" },
        { Guid.Parse("f74c980b-8fc9-447b-a87e-e3ae8aa53815"), "Epsifund" }
    };
    private readonly RequestDelegate next;

    public APIKeyMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value.Contains("/api/docs") ||
            context.Request.Path.Value.Contains("swagger"))
        {
            await next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(HeaderNames.ApiKeyHeaderName, out var apiKeys))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var apikey = apiKeys.FirstOrDefault();
        if (apikey is null ||
            !Guid.TryParse(apikey, out var guidApiKey) ||
            !ApiKeys.TryGetValue(guidApiKey, out var existsProviderName))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var claims = service.Service.Claims.Select(c => new Claim(c.Name, c.Name)).ToList();
        var identity = new ClaimsIdentity(claims, "ApiKeyAuthentication");
        context.User = new ClaimsPrincipal(identity);

        context.SetApp(existsProviderName);

        await next(context);

    }
}