using System.Net;
using System.Text.Json;
using StrokePrediction.API.dtos;

namespace StrokePrediction.API.middlewares;

/// <summary>
/// Global Exception Handler Middleware
/// Bắt tất cả exception chưa xử lý, trả về ErrorResponseDto chuẩn
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private static readonly JsonSerializerOptions _json = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            _logger.LogWarning("Request cancelled by client: {Path}", context.Request.Path);
            context.Response.StatusCode = 499;   // Client Closed Request
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Path}", context.Request.Path);
            await WriteErrorAsync(context, ex);
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, Exception ex)
    {
        var (statusCode, message) = ex switch
        {
            ArgumentException    => (HttpStatusCode.BadRequest, ex.Message),
            KeyNotFoundException => (HttpStatusCode.NotFound, ex.Message),
            TimeoutException     => (HttpStatusCode.GatewayTimeout, "ML service timed out"),
            _                    => (HttpStatusCode.InternalServerError, "Internal server error")
        };

        var response = new ErrorResponseDto
        {
            Error  = message,
            Detail = ex.Message + (ex.InnerException != null ? " | " + ex.InnerException.Message : "")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode  = (int)statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, _json));
    }
}

public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        => app.UseMiddleware<GlobalExceptionMiddleware>();
}
