using Basket.Domain.Entities;
using System.Threading.Tasks;

namespace Basket.Domain.Reposities
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
