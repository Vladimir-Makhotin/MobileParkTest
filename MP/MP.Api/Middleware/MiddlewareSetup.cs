namespace MP.Api.Middleware
{
    public static class MiddlewareSetup
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeZoneMiddleware>();
        }
    }
}
