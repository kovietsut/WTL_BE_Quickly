using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors;

public class AuditFieldsInterceptor(IHttpContextAccessor httpContextAccessor) : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetAuditFields(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        SetAuditFields(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetAuditFields(DbContext? context)
    {
        if (context == null) return;

        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value
                     ?? _httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value
                     ?? _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State is EntityState.Added or EntityState.Modified))
        {
            var now = DateTimeOffset.UtcNow;

            if (entry.Entity is Domain.Entities.Interfaces.IHasTimestamps timestamps)
            {
                if (entry.State == EntityState.Added)
                {
                    timestamps.CreatedAt = now;
                }
                timestamps.UpdatedAt = now;
            }

            if (entry.Entity is Domain.Entities.Interfaces.IHasUserAudit userAudit)
            {
                if (entry.State == EntityState.Added)
                {
                    userAudit.CreatedBy = userId;
                }
                userAudit.ModifiedBy = userId;
            }
        }
    }
    
}


