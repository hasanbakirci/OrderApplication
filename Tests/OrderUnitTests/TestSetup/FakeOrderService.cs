using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using OrderService.Dtos.Requests;
using OrderService.Dtos.Responses;
using OrderService.Services;

namespace OrderUnitTests.TestSetup
{
    public class FakeOrderService : IOrdersService
    {
        private readonly List<Order> _fakeOrderRepo;
        private readonly Address _address;
        private readonly Product _product;
        private readonly Customer _customer;
        public FakeOrderService()
        {
            _address = new Address{Id = 1,AddressLine="A caddresi No: 1",City="Aa",Country="AAA",CityCode=1};
            _customer = new Customer{Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),Name="customer 1",Email="customer1@mail.com",AddressId=1,CreatedAt= new DateTime(2001,06,21),UpdatedAt= new DateTime(2001,06,22),Address=_address};
            _product = new Product{Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),ImageUrl="ProductImage",Name="ProductName"};
            _fakeOrderRepo = new List<Order>(){
                new Order(){Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa"),CreatedAt= new DateTime(2001,06,21),UpdatedAt= new DateTime(2001,06,22),Price = 10,Quantity = 10,Status="1",AddressId=1,Address=_address,CustomerId=new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),ProductId=new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),Product=_product},
                new Order(){Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),CreatedAt= new DateTime(2001,06,11),UpdatedAt= new DateTime(2001,06,12),Price = 11,Quantity = 11,Status="11",AddressId=1,Address=_address,CustomerId=new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),ProductId=new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),Product=_product} 
            };
        }
        public Task<bool> ChangeStatus(Guid id, string status)
        {
            var order = _fakeOrderRepo.Any(a => a.Id == id);
            if(order){
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Guid> Create(CreateOrderRequest request)
        {
            var order = new Order(){
                Id= Guid.NewGuid(),
                CustomerId= new Guid("b22602aa-d850-4de9-b337-2fbc3dcd5caa"),
                Quantity = request.Quantity,
                Price = request.Price,
                Status = request.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ProductId = request.ProductId,
                Product = _product,
                AddressId=request.AddressId,
                Address=_address,
                };
            _fakeOrderRepo.Add(order);
            return Task.FromResult(order.Id);
        }

        public Task<bool> Delete(Guid id)
        {
            
            return Task.FromResult(true);
            
        }

        public Task<IEnumerable<OrderResponse>> Get()
        {
            var result = _fakeOrderRepo.ConvertToListDto();
            return Task.FromResult(result);
        }

        public Task<OrderResponse> GetById(Guid id)
        {
            var order = _fakeOrderRepo.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(order.ConvertToDto());
        }

        public Task<IEnumerable<OrderResponse>> GetByCustomerId(Guid id)
        {
            var orders = _fakeOrderRepo.Where(x => x.CustomerId == id).ToList();
            return Task.FromResult(orders.ConvertToListDto());
        }

        public Task<bool> OrderIsExist(Guid id)
        {
            var order = _fakeOrderRepo.Any(a => a.Id == id);
            if(order){
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> Update(UpdateOrderRequest request)
        {
            var order = _fakeOrderRepo.Any(a => a.Id == request.Id);
            if(order){
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        
    }
}