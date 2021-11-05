using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;

namespace CustomerService.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> Get();
        Task<CustomerResponse> GetById(Guid id);
        Task<Guid> Create(CreateCustomerRequest request);
        Task<bool> Update(UpdateCustomerRequest request);
        Task<bool> Delete(Guid id);
        Task<bool> Validate(Guid id);
    }
}