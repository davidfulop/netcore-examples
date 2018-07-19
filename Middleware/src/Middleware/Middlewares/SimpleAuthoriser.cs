using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Middleware.Middlewares
{
    public class SimpleAuthoriser
    {
        private readonly RequestDelegate _next;
        private readonly string _key;

        public SimpleAuthoriser(RequestDelegate next, string key)
        {
            _next = next;
            _key = key;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringValues key;
            if (context.Request.Headers.TryGetValue("Secret", out key) && key == _key)
                await _next(context);
            else context.Response.StatusCode = 401;
        }
    }

    public static class SimpleAuthoriserMiddlewareExtensions
    {        
        public static IApplicationBuilder UseSimpleAuthoriserMiddleware(this IApplicationBuilder builder, string key)
        {
            return builder.UseMiddleware<SimpleAuthoriser>(key);
        }
    }
}
