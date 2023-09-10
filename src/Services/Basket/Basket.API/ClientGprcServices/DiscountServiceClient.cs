using Discount.Gprc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.ClientGprcServices
{
     public class DiscountServiceClient 
    {
        private readonly Discount.Gprc.DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountServiceClient(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient;
        }

       public async Task<DiscountModal> CheckDisountAsync(CouponRequet couponRequet)
        {
            var x = await _discountProtoServiceClient.GetDiscountAsync(couponRequet);
            return x;
        }
    }
}
