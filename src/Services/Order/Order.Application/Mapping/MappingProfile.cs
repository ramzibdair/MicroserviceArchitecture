using AutoMapper;
using Order.Application.Features.CheckoutOrder;
using Order.Application.Features.CreateOrder;
using Order.Application.Features.RetrieveOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Order, OrdersVM>().ReverseMap();
            CreateMap<Domain.Entities.Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
