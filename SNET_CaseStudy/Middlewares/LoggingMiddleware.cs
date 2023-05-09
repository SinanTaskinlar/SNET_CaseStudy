using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SNET_CaseStudy.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request
            _logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} received");

            // Copy the response
            var bodyStream = context.Response.Body;
            var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            // Call the next middleware
            await _next(context);

            // Log the response
            responseBody.Seek(0, SeekOrigin.Begin);
            string responseBodyContent = new StreamReader(responseBody).ReadToEnd();
            _logger.LogInformation($"Response {context.Response.StatusCode} {responseBodyContent}");

            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(bodyStream);
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}