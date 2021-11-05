using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Controllers;
using CustomerService.Dtos.Requests;
using CustomerService.Services;
using CustomerUnitTests.TestSetup;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CustomerUnitTests
{
    public class CustomerServiceTests
    {
        private readonly CustomersController _controller;
        private readonly ICustomerService _service;
        public CustomerServiceTests()
        {
            _service = new FakeCustomerService();
            _controller = new CustomersController(_service);
        }
        [Fact]
        public async Task Get_WhenCalled_ReturnOkResult(){
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
        [Theory]
        [InlineData(1,"deneme@mail.com","deneme")]
        public void CreateValidator_WhenCalled_ReturnTrue(int addressId,string email, string name){
            var request = new CreateCustomerRequest(){
                AddressId = addressId,
                Email = email,
                Name = name
            };
            CreateCustomerRequestValidator validator = new CreateCustomerRequestValidator();
            var validate = validator.Validate(request);
            Assert.True(validate.IsValid);
        }
        [Theory]
        [InlineData(0,"deneme@mail.com","deneme")]
        [InlineData(1,"deneme","deneme")]
        [InlineData(1,"deneme@mail.com","d")]
        public void CreateValidator_WhenCalled_ReturnFalse(int addressId,string email, string name){
            var request = new CreateCustomerRequest(){
                AddressId = addressId,
                Email = email,
                Name = name
            };
            CreateCustomerRequestValidator validator = new CreateCustomerRequestValidator();
            var validate = validator.Validate(request);
            Assert.False(validate.IsValid);
        }
        [Theory]
        [InlineData(1,"deneme@mail.com","deneme")]
        public void UpdateValidator_WhenCalled_ReturnTrue(int addressId,string email, string name){
            var request = new UpdateCustomerRequest(){
                AddressId = addressId,
                Email = email,
                Name = name,
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa")
            };
            UpdateCustomerRequestValidator validator = new UpdateCustomerRequestValidator();
            var validate = validator.Validate(request);
            Assert.True(validate.IsValid);
        }
        [Theory]
        [InlineData(0,"deneme@mail.com","deneme")]
        [InlineData(1,"deneme","deneme")]
        [InlineData(1,"deneme@mail.com","de")]
        [InlineData(0,"deneme","d")]
        public void UpdateValidator_WhenCalled_ReturnFalse(int addressId,string email, string name){
            var request = new UpdateCustomerRequest(){
                AddressId = addressId,
                Email = email,
                Name = name,
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5caa")
            };
            UpdateCustomerRequestValidator validator = new UpdateCustomerRequestValidator();
            var validate = validator.Validate(request);
            Assert.False(validate.IsValid);
        }
        [Fact]
        public async Task Update_WhenCalled_ReturnNotFoundResult(){
            var request = new UpdateCustomerRequest(){
                Id = new Guid("a22602aa-d850-4de9-b337-2fbc3dcd5ca1")
            };
            var result = await _controller.Update(request);
            Assert.IsType<NotFoundObjectResult>(result as NotFoundObjectResult);
        }

    }
}