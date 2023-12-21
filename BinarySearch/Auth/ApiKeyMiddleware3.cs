using System.Security.Claims;

namespace BinarySearch.Auth
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ServiceService _serviceService;

        public ApiKeyMiddleware(RequestDelegate next, ServiceService serviceService)
        {
            _next = next;
            _serviceService = serviceService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var service = _serviceService.GetServiceByApiKey(apiKey);

            if (service == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var claims = service.Service.Claims.Select(c => new Claim(c.Name, c.Name)).ToList();
            var identity = new ClaimsIdentity(claims, "ApiKeyAuthentication");
            context.User = new ClaimsPrincipal(identity);

            await _next(context);
        }
    }
}
