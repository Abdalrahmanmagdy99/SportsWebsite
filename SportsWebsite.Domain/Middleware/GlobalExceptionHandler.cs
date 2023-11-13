using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SportsWebsite.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message + "Inner Exception : " + ex.InnerException);
                context.Response.Redirect("/Home/Error");
            }
        }
    }
}
