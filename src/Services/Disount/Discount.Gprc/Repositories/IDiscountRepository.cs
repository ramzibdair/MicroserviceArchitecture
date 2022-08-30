using Discount.Gprc.Entities;
using System.Threading.Tasks;

namespace Discount.Gprc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscountAsync(string productName);
        Task<Coupon> GetDiscountByIDAsync(string productID);
        Task<Coupon> CreateDiscountAsync(Coupon Coupon);
        Task<bool> DeleteDiscountAsync(string productName);
        Task<Coupon> UpdateDiscountAsync(Coupon coupon);

    }
}
