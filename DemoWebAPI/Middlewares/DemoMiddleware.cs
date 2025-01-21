using DemoWebAPI.Services;

namespace DemoWebAPI.Middlewares
{
    public class DemoMiddleware
    {
        private readonly RequestDelegate _next;

        private SessionService _session;

        public DemoMiddleware(RequestDelegate next, SessionService session)
        {
            _next = next;
            _session = session;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }
}
