using AutoMapper;
using Order.Application.Features.CreateOrder;
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
            CreateMap<Order.Domain.Entities.Order, CreateOrderCommand>().ReverseMap();
        }
    }
}
