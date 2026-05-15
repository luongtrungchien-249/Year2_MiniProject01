using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Core.entities;
using System.Security.Claims;
using System.Text.Json;

namespace StrokePrediction.API.filters
{
    /// <summary>
    /// Global Action Filter để tự động ghi Audit Log cho mọi API thành công
    /// </summary>
    public class GlobalAuditFilter : IAsyncActionFilter
    {
        private readonly IAuditRepository _auditRepo;
        private readonly ILogger<GlobalAuditFilter> _logger;

        public GlobalAuditFilter(IAuditRepository auditRepo, ILogger<GlobalAuditFilter> logger)
        {
            _auditRepo = auditRepo;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Thực thi Action
            var executedContext = await next();

            // Chỉ log nếu Action thành công (200 OK)
            if (executedContext.Result is OkObjectResult okObj)
            {
                try
                {
                    await LogActionAsync(context, okObj.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to write audit log for {Path}", context.HttpContext.Request.Path);
                }
            }
            else if (executedContext.Result is OkResult)
            {
                try
                {
                    await LogActionAsync(context, null);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to write audit log for {Path}", context.HttpContext.Request.Path);
                }
            }
        }

        private async Task LogActionAsync(ActionExecutingContext context, object? resultValue)
        {
            var request = context.HttpContext.Request;
            var path = request.Path.Value?.ToLower() ?? "";
            
            // Lấy User ID từ Claims
            var userIdStr = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? userId = int.TryParse(userIdStr, out var id) ? id : null;

            AuditAction action;
            string? entityType = null;
            int? entityId = null;
            
            // Mapping Path -> AuditAction
            if (path.Contains("/auth/login")) 
            {
                action = AuditAction.LOGIN;
                // Lấy ID từ kết quả trả về của AuthController
                if (resultValue != null)
                {
                    var json = JsonSerializer.Serialize(resultValue);
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("id", out var idProp))
                        userId = idProp.GetInt32();
                }
            }
            else if (path.Contains("/auth/logout")) action = AuditAction.LOGOUT;
            else if (path.Contains("/predictions") && request.Method == "POST") return; // Đã log trong Repository
            else if (path.Contains("/predictions") && request.Method == "GET") action = AuditAction.VIEW_HISTORY;
            else if (path.Contains("/stats")) action = AuditAction.VIEW_HISTORY;
            else if (path.Contains("/models")) action = AuditAction.VIEW_HISTORY;
            else return;

            var detail = new
            {
                method = request.Method,
                path = path,
                queryString = request.QueryString.ToString(),
                timestamp = DateTime.UtcNow
            };

            await _auditRepo.LogAsync(
                userId: userId,
                action: action,
                entityType: entityType,
                entityId: entityId,
                detail: JsonSerializer.Serialize(detail),
                ipAddress: context.HttpContext.Connection.RemoteIpAddress?.ToString()
            );
        }
    }
}
