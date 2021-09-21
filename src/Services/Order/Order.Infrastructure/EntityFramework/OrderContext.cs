using Microsoft.EntityFrameworkCore;
using Order.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Infrastructure.EntityFramework
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.AddCreationValue(DateTime.Now, "RAMZI");
                        break;
                    case EntityState.Modified:
                        entry.Entity.AddModificationValue(DateTime.Now, "RAMZI");
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
