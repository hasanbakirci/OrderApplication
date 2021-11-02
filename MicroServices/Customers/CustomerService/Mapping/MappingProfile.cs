using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;
using Data.Model;

namespace CustomerService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponse>().ForMember(dest => dest.AddressResponse, opt => opt.MapFrom(src => 
                        src.Address.AddressLine+" , "+src.Address.City+" , "+src.Address.CityCode+" , "+src.Address.Country
                    ));
            CreateMap<CreateCustomerRequest, Customer>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressId));
            CreateMap<UpdateCustomerRequest, Customer>();
            
        }
    }
}