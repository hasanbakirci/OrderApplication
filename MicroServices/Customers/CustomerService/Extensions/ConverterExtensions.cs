using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;
using Data.Model;

namespace CustomerService.Extensions
{
    public static class ConverterExtensions
    {
        public static IEnumerable<CustomerResponse> ConvertToCustomerListResponse(this IEnumerable<Customer> customers, IMapper mapper){
            var responses = mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return responses;
        }
        public static CustomerResponse ConvertToCustomerResponse(this Customer customer, IMapper mapper){
            var response = mapper.Map<CustomerResponse>(customer);
            return response;
        }
        public static Customer ConvertToCustomer(this CreateCustomerRequest createCustomerRequest, IMapper mapper){
            return mapper.Map<Customer>(createCustomerRequest);
        }
        public static Customer ConvertToCustomer(this UpdateCustomerRequest updateCustomerRequest, IMapper mapper){
            return mapper.Map<Customer>(updateCustomerRequest);
        }
    }
}