using System;
using System.Threading;
using System.Threading.Tasks;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Core.entities;
using StrokePrediction.Infrastructure.database;

namespace StrokePrediction.Infrastructure.repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly AppDbContext _db;

        public AuditRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task LogAsync(int? userId, AuditAction action, string? entityType = null, int? entityId = null, string? detail = null, string? ipAddress = null, CancellationToken ct = default)
        {
            var log = new AuditLogEntity
            {
                UserId = userId,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                Detail = detail,
                IpAddress = ipAddress,
                CreatedAt = DateTime.UtcNow
            };

            _db.AuditLogs.Add(log);
            await _db.SaveChangesAsync(ct);
        }
    }
}
