using System.Diagnostics;

namespace DevFlowAI.API.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        var method = context.Request.Method;
        var path = context.Request.Path;

        _logger.LogInformation("HTTP {Method} {Path} iniciado", method, path);

        await _next(context);

        stopwatch.Stop();

        var statusCode = context.Response.StatusCode;
        var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        _logger.LogInformation(
            "HTTP {Method} {Path} finalizado com status {StatusCode} em {ElapsedMilliseconds}ms",
            method,
            path,
            statusCode,
            elapsedMilliseconds);
    }
}