using Microsoft.EntityFrameworkCore;
using Order.Domain.Abstraction;
using System;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                      .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                {
                    property.SetMaxLength(256);
                }

                if (string.IsNullOrEmpty(property.GetColumnType()))
                {
                    property.SetColumnType("varchar");
                }
            }
            modelBuilder.ApplyConfiguration(new OrderEntitiesConfiguration());
        }

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
