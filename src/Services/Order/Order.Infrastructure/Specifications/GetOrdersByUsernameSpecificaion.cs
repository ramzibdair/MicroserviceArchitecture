using Order.Infrastructure.EntityFramework.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Specifications
{
    internal class GetOrdersByUsernameSpecificaion : Specification<Domain.Entities.Order>
    {
        public GetOrdersByUsernameSpecificaion(string username) : base(oder => string.IsNullOrEmpty(username) || oder.UserName.Contains(username))
        {
            AddInclude(order => order.Products);
            AddOrderBy(order => order.LastModifiedBy);
        }
    }
}
