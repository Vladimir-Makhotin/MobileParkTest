using System.Security.Claims;

namespace MP.Api.Middleware
{
    public class TimeZoneMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeZoneMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? timeZoneId = context.Request.Headers["Time-Zone"];
            if (timeZoneId is null)
                if (context.User?.Identity is ClaimsIdentity identity)
                {
                    Claim? timeZoneClaim = identity.FindFirst("Time-Zone");
                    if (timeZoneClaim is not null)
                        timeZoneId = timeZoneClaim.Value;
                }

            if (timeZoneId is not null)
                try
                {
                    TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                    context.Items["Time-Zone"] = timeZone;
                }
                catch (TimeZoneNotFoundException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid Time-Zone");
                    return;
                }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Time-Zone header or Claim is required");
                return;
            }

            await _next(context);
        }
    }
}
