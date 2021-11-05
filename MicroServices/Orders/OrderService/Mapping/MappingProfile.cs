using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using OrderService.Dtos.Requests;
using OrderService.Dtos.Responses;

namespace OrderService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderResponse>()
                    .ForMember(dest => dest.ProductResponse,
                                opt => opt.MapFrom(src => 
                                src.Product.ImageUrl+" , "+src.Product.Name+" , "+src.ProductId))
                    .ForMember(dest => dest.AddressResponse,
                                opt => opt.MapFrom(src => 
                                src.Address.AddressLine+" , "+src.Address.City+" , "+src.Address.CityCode+" , "+src.Address.Country+" , "+src.AddressId));
            CreateMap<CreateOrderRequest, Order>()
                    .ForMember(dest => dest.ProductId, 
                                opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest => dest.AddressId, 
                                opt => opt.MapFrom(src => src.AddressId));
            CreateMap<UpdateOrderRequest, Order>();
            
        }
    }
}