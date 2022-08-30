using Discount.Gprc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace Discount.Gprc
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly ILogger<DiscountService> _logger;
        private readonly IDiscountRepository _discountRepository;
        public DiscountService(ILogger<DiscountService> logger , IDiscountRepository discountRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        }

        public override async Task<DiscountModal> GetDiscount(CouponRequet request, ServerCallContext context)
        {
            _logger.LogInformation($"Get Discount ");
            var discount = await _discountRepository.GetDiscountByIDAsync(request.ProductId);
            if(discount != null)
            {
                return new DiscountModal
                {
                    Amount = discount.Amount,
                    Description = discount.Description,
                    Id = discount.ID,
                    ProductName = discount.ProductName

                };
            }
            return null;
        }
    }
}
