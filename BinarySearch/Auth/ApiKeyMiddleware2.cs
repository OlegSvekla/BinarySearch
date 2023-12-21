using System.Security.Claims;

namespace BinarySearch.Auth
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, YourDbContext dbContext)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var service = dbContext.Services
                .Include(s => s.ApiKeys)
                .Include(s => s.Claims)
                .FirstOrDefault(s => s.ApiKeys.Any(k => k.EncryptedKey == apiKey));

            if (service == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var claims = service.Claims.Select(c => new Claim(c.Name, c.Name)).ToList();
            var identity = new ClaimsIdentity(claims, "ApiKeyAuthentication");
            context.User = new ClaimsPrincipal(identity);

            await _next(context);
        }
    }

}
