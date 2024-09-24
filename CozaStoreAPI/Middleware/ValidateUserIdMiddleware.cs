using System.Security.Claims;

namespace CozaStoreAPI.Middleware
{
    public class ValidateUserIdMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidateUserIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                if (Guid.TryParse(userId, out _))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid user ID format.");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("User ID is missing.");
                return;
            }
        }
    }

}
