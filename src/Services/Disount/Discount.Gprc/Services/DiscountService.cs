using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace Discount.Gprc
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ILogger<DiscountService> _logger;
        public DiscountService(ILogger<DiscountService> logger)
        {
            _logger = logger;
        }

        public override Task<DiscountModal> GetDiscount(CouponRequet request, ServerCallContext context)
        {
            return Task.FromResult(new DiscountModal
            {
                Amount = 100,
                Description = "Yearly disount",
                Id = 1,
                ProductName = "Item 1"

            });
        }
    }
}
