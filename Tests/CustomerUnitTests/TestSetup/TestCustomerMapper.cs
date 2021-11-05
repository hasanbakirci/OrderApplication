using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Dtos.Responses;
using Data.Model;

namespace CustomerUnitTests.TestSetup
{
    public static class TestCustomerMapper
    {
        public static IEnumerable<CustomerResponse> ConvertToListDto(this List<Customer> customers){
            List<CustomerResponse> customerResponses = new List<CustomerResponse>();
            customers.ToList().ForEach(customer => customerResponses.Add(new CustomerResponse
            {
                id = customer.Id,
                AddressResponse = customer.AddressId.ToString(),
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                Email = customer.Email,
                Name = customer.Name
            }));
            return customerResponses;
        }
        public static CustomerResponse ConvertToDto(this Customer customer){
            CustomerResponse customerResponse = new CustomerResponse();
            customerResponse = new CustomerResponse
            {
                id = customer.Id,
                AddressResponse = customer.AddressId.ToString(),
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                Email = customer.Email,
                Name = customer.Name
            };
            return customerResponse;
        }
    }
}