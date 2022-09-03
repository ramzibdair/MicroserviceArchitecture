using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Abstraction
{
    public interface IOrderRepository : IAsyncRepository<Domain.Entities.Order>
    {
        Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserName(string userName);
    }
}
