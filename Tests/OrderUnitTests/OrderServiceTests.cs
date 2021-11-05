using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.OrderRepository;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Controllers;
using OrderService.Dtos.Requests;
using OrderService.Services;
using OrderUnitTests.TestSetup;
using Xunit;

namespace OrderUnitTests
{
    public class OrderServiceTests
    {
        private readonly OrdersController _controller;
        private readonly IOrdersService _service;
        public OrderServiceTests()
        {
            _service = new FakeOrderService();
            _controller = new OrdersController(_service);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnOkResult(){
            //Act
            var result = await _controller.Get();
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task GetById_WhenCalled_ReturnOkResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa");
            var result = await _controller.GetById(id);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task GetById_WhenCalled_ReturnNotFoundResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5ca1");
            var result = await _controller.GetById(id);
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }
        [Fact]
        public async Task Delete_WhenCalled_ReturnOkResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa");
            var result = await _controller.Delete(id);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task Delete_WhenCalled_ReturnNotFoundResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5ca1");
            var result = await _controller.Delete(id);
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }
        [Fact]
        public async Task GetByCustomerId_WhenCalled_ReturnOkResult(){
            var id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
            var result = await _controller.GetByCustomerId(id);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task GetByCustomerId_WhenCalled_ReturnNotFoundResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5ca1");
            var result = await _controller.GetByCustomerId(id);
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }
        [Fact]
        public async Task ChangeStatus_WhenCalled_ReturnOkResult(){
            var id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa");
            var result = await _controller.ChangeStatus(id,"Deger");
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task ChangeStatus_WhenCalled_ReturnNotFoundResult(){
            var id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
            var result = await _controller.ChangeStatus(id,"Deger");
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }
        [Theory]
        [InlineData(1,10,10,"qwe")]
        public void UpdateValidator_WhenCalled_ReturnTrue(int addressId,double price,int quantity,string status){
            var request = new UpdateOrderRequest(){
                AddressId = addressId,
                CustomerId = new Guid(),
                Price = price,
                Quantity = quantity,
                Status = status,
                ProductId = new Guid(),
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa")
            };
            UpdateOrderRequestValidator validator = new UpdateOrderRequestValidator();
            var validate = validator.Validate(request);
            Assert.True(validate.IsValid);   
        }
        [Theory]
        [InlineData(0,10,10,"qwe")]
        [InlineData(1,0,10,"qwe")]
        [InlineData(1,10,0,"qwe")]
        [InlineData(1,10,10,"q")]
        public void UpdateValidator_WhenCalled_ReturnFalse(int addressId,double price,int quantity,string status){
            var request = new UpdateOrderRequest(){
                AddressId = addressId,
                CustomerId = new Guid(),
                Price = price,
                Quantity = quantity,
                Status = status,
                ProductId = new Guid(),
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa")
            };
            UpdateOrderRequestValidator validator = new UpdateOrderRequestValidator();
            var validate = validator.Validate(request);
            Assert.False(validate.IsValid);   
        }
        [Fact]
        public async Task Update_WhenCalled_ReturnNotFoundResult(){
            var request = new UpdateOrderRequest(){
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5ca1")
            };
            var result = await _controller.Update(request);
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }
        [Theory]
        [InlineData(1,10,10,"qwe")]
        public void CreateValidator_WhenCalled_ReturnTrue(int addressId,double price,int quantity,string status){
            var request = new CreateOrderRequest(){
                AddressId = addressId,
                CustomerId = new Guid("d22602aa-d850-4de9-b337-2fbc3dcd5ca1"),
                Price = price,
                Quantity = quantity,
                Status = status,
                ProductId = new Guid("c22602aa-d850-4de9-b337-2fbc3dcd5ca1")
            };
            CreateOrderRequestValidator validator = new CreateOrderRequestValidator();
            var validate = validator.Validate(request);
            Assert.True(validate.IsValid);   
        }
        [Theory]
        [InlineData(0,10,10,"qwe","33704c4a-5b87-464c-bfb6-51971b4d18ad","815accac-fd5b-478a-a9d6-f171a2f6ae7f")]
        [InlineData(1,0,10,"qwe","33704c4a-5b87-464c-bfb6-51971b4d18ad","815accac-fd5b-478a-a9d6-f171a2f6ae7f")]
        [InlineData(1,10,0,"qwe","33704c4a-5b87-464c-bfb6-51971b4d18ad","815accac-fd5b-478a-a9d6-f171a2f6ae7f")]
        [InlineData(1,10,10,"q","33704c4a-5b87-464c-bfb6-51971b4d18ad","815accac-fd5b-478a-a9d6-f171a2f6ae7f")]
        [InlineData(1,10,10,"qwe",null,"815accac-fd5b-478a-a9d6-f171a2f6ae7f")]
        [InlineData(1,10,10,"qwe","33704c4a-5b87-464c-bfb6-51971b4d18ad",null)]
        public void CreateValidator_WhenCalled_ReturnFalse(int addressId,double price,int quantity,string status,Guid productId,Guid customerId){
            var request = new CreateOrderRequest(){
                AddressId = addressId,
                CustomerId = customerId,
                Price = price,
                Quantity = quantity,
                Status = status,
                ProductId = productId
            };
            CreateOrderRequestValidator validator = new CreateOrderRequestValidator();
            var validate = validator.Validate(request);
            Assert.False(validate.IsValid);   
        }

    }
}