using System.Net;
using System.Text.Json;

namespace NTierProject.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Bir hatayla karşılaşıldı: " + exception.Message);

            }
        }
    }
}
