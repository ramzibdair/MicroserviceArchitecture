using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Specifications
{
    internal class GetOrderByIdSpecification : Specification<Domain.Entities.Order>
    {
        public GetOrderByIdSpecification(int id) : base(order=>order.Id == id)
        {
            AddInclude(order => order.Products);
        }
    }
}
