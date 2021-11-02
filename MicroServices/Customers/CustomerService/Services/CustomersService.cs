using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;
using CustomerService.Extensions;
using Data.Repositories.CustomerRepository;

namespace CustomerService.Services
{
    public class CustomersService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CreateCustomerRequest request)
        {
            var customer = request.ConvertToCustomer(_mapper);
            var id = await _customerRepository.Create(customer);
            return id;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _customerRepository.Delete(id);
        }

        public async Task<IEnumerable<CustomerResponse>> Get()
        {
            var customers = await _customerRepository.Get();
            var response = customers.ConvertToCustomerListResponse(_mapper);
            return response;
        }

        public async Task<CustomerResponse> Get(Guid id)
        {
            var customer = await _customerRepository.Get(id);
            var response = customer.ConvertToCustomerResponse(_mapper);
            return response;
        }

        public async Task<bool> Update(UpdateCustomerRequest request)
        {
            var customer = request.ConvertToCustomer(_mapper);
            return await _customerRepository.Update(customer);
        }

        public async Task<bool> Validate(Guid id)
        {
            return await _customerRepository.Validate(id);
        }
    }
}