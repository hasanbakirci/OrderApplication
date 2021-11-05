using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;
using CustomerService.Services;
using Data.Model;

namespace CustomerUnitTests.TestSetup
{
    public class FakeCustomerService : ICustomerService
    {
        private readonly List<Customer> _fakeCustomerRepo;
        private readonly Address _address;
        public FakeCustomerService()
        {
            _address = new Address{Id = 1,AddressLine="A caddresi No: 1",City="Aa",Country="AAA",CityCode=1};
            _fakeCustomerRepo = new List<Customer>{
                new Customer(){Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa"),Address= _address,AddressId = 1,Email="customer1@mail.com",Name="Customer1",CreatedAt= new DateTime(2001,06,21),UpdatedAt= new DateTime(2001,06,22)},
                new Customer(){Id = new Guid("b22602aa-d850-4de9-b337-2fbc3dcd5caa"),Address= _address,AddressId = 1,Email="customer2@mail.com",Name="Customer2",CreatedAt= new DateTime(2001,06,23),UpdatedAt= new DateTime(2001,06,24)}
            };
        }
        public Task<IEnumerable<CustomerResponse>> Get()
        {
            var result = _fakeCustomerRepo.ConvertToListDto();
            return Task.FromResult(result);
        }

        public Task<CustomerResponse> GetById(Guid id)
        {
            var customer = _fakeCustomerRepo.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(customer.ConvertToDto());
        }
        public Task<bool> Delete(Guid id)
        {
            return Task.FromResult(true);
        }
        public Task<bool> Validate(Guid id)
        {
            var customer = _fakeCustomerRepo.Any(a => a.Id == id);
            if(customer){
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        public Task<Guid> Create(CreateCustomerRequest request)
        {
            var customer = new Customer(){
                Id = Guid.NewGuid(),
                Address = _address,
                AddressId = request.AddressId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Email = request.Email,
                Name = request.Name
            };
            _fakeCustomerRepo.Add(customer);
            return Task.FromResult(customer.Id);
        }

        public Task<bool> Update(UpdateCustomerRequest request)
        {
            var customer = _fakeCustomerRepo.Any(a => a.Id == request.Id);
            if(customer){
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}