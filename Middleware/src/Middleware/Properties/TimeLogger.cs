using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.Middlewares
{
    public class TimeLogger
    {
        private readonly RequestDelegate _next;

        public TimeLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"--- Start: {DateTime.Now.ToLongTimeString()}");
            Stopwatch sw = Stopwatch.StartNew();
        
            await _next(context);
        
            sw.Stop();
            Console.WriteLine($"--- Duration: {sw.ElapsedMilliseconds}");
        }
    }
}