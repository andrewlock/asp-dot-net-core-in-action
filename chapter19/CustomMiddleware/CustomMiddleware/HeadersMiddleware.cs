using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware
{
    public class HeadersMiddleware
    {
        private readonly RequestDelegate _next;
        const int MaxAgeInSeconds = 60;

        public HeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["Strict-Transport-Security"] = $"max-age={MaxAgeInSeconds}";
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
