using Microsoft.EntityFrameworkCore;
using Order.Domain.Repositories;
using Order.Infrastructure.EntityFramework;
using Order.Infrastructure.Specifications;
using System.Collections.Generic;
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
            //var orderList = await _dbContext.Orders
            //                        .Where(o => o.UserName == userName)
            //                        .ToListAsync();
            var orderList = await ApplySpecification(new GetOrdersByUsernameSpecificaion(userName)).ToListAsync();
            return orderList;
        }

    }
}
