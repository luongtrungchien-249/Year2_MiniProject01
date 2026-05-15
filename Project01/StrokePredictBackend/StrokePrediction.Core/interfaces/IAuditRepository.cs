using System.Threading;
using System.Threading.Tasks;
using StrokePrediction.Core.entities;

namespace StrokePrediction.Core.interfaces
{
    public interface IAuditRepository
    {
        Task LogAsync(int? userId, AuditAction action, string? entityType = null, int? entityId = null, string? detail = null, string? ipAddress = null, CancellationToken ct = default);
    }
}
