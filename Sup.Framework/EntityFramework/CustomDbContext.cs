using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sup.Framework.Base.Extensions;
using Sup.Framework.Domain.Auditing;
using Sup.Framework.Domain.Validation;
using Sup.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sup.Framework.EntityFramework
{
    public abstract class CustomDbContext:DbContext
    {
        public CustomDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public override int SaveChanges()
        {
            ApplyPreChanges();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyPreChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ApplyPreChanges();
            return base.SaveChangesAsync(cancellationToken);
        }
        protected virtual void ApplyPreChanges()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                ApplyPreChanges(entry);
            }
        }
        protected virtual void ApplyPreChanges(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ApplyPreEditChanges(entry);
                    break;
                case EntityState.Modified:
                    
                    ApplyPreEditChanges(entry);
                    break;
                case EntityState.Deleted:
                   
                    break;
            }
            if (entry.Entity is IObjectValidator)
            {
                if(!entry.Entity.As<IObjectValidator>().IsValid())
                {
                    throw new ObjectNotValidException("Object is not valid!");
                }
            }
        }
        protected virtual void ApplyPreEditChanges(EntityEntry entry)
        {
            if(entry.Entity is IHasLastUpdateTime)
            {
                entry.Entity.As<IHasLastUpdateTime>().LastUpdateTime = DateTime.Now;
            }
        }
    }
}
