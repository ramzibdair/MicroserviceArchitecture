using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.EntityFramework.Seed
{
    public class OderSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OderSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        } 

        private static IEnumerable<Domain.Entities.Order> GetPreconfiguredOrders()
        {
            return new List<Domain.Entities.Order>
            {
                new Domain.Entities.Order("ramzi",100m,"Ramzi","Bdair","ramzi_bdeir@yahoo.com", "Riyadh", "KSA","state","1234","Ramzi M Bdair","123456789123456789","22/12","123",1)
            };
        }
    }
}
