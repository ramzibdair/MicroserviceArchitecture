
using System.Collections.Generic;
using System.Threading.Tasks;
using Order.Domain.Abstraction;

namespace Order.Domain.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Entities.Order>
    {
        Task<IEnumerable<Entities.Order>> GetOrdersByUserName(string userName);
    }
}