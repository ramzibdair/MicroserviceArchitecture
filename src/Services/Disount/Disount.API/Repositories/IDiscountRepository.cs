using Disount.API.Entities;
using System.Threading.Tasks;

namespace Disount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscountAsync(string productName);
        Task<Coupon> CreateDiscountAsync(Coupon Coupon);
        Task<bool> DeleteDiscountAsync(string productName);
        Task<Coupon> UpdateDiscountAsync(Coupon coupon);

    }
}
