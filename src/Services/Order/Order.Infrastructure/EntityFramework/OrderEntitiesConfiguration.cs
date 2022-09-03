using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Order.Infrastructure.EntityFramework
{
   public class OrderEntitiesConfiguration : IEntityTypeConfiguration<Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order> builder)
        {
   
            builder.ToTable("Order", "dbo");
            builder.HasKey(r => r.Id);
            builder.OwnsOne(r => r.BillingAddress);
            builder.OwnsOne(r => r.Payment);
        }
    }
}
