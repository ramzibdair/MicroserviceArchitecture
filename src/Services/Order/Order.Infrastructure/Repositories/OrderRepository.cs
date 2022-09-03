using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.EntityFramework;
using Order.Domain.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Domain.Entities.Order>, IOrderRepository
    {
        private readonly OrderContext _dbContext;
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
            _dbContext = orderContext ?? throw new System.ArgumentNullException();
        }
        public async Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                    .Where(o => o.UserName == userName)
                                    .ToListAsync();
            return orderList;
        }
    }
}
