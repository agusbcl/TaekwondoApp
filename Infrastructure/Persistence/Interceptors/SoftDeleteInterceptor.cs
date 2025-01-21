using Domain.SoftDelete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence.Interceptors
{
    public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData,
    InterceptionResult<int> result,
    CancellationToken cancellationToken = default
    )
        {
            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<ISoftDeleteable>> entries =
                eventData
                    .Context
                    .ChangeTracker
            .Entries<ISoftDeleteable>()
                    .Where(e => e.State == EntityState.Deleted);
            foreach (EntityEntry<ISoftDeleteable> softDeletable in entries)
            {
                softDeletable.State = EntityState.Modified;
                softDeletable.Entity.IsDeleted = true;
                softDeletable.Entity.DeletedOnUtc = DateTime.UtcNow;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
