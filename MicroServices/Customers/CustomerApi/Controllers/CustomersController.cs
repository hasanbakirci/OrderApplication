using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Dtos.Requests;
using CustomerService.Dtos.Responses;
using CustomerService.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var customers = await _customerService.Get();
            return Ok(customers);
        }
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id){
            var isValidate = await _customerService.Validate(id);
            if(isValidate){
                var customer = await _customerService.GetById(id);
                return Ok(customer); 
            }
            return NotFound("Id Not Found !"); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
            var isValidate = await _customerService.Validate(id);
            if(isValidate){
                var result = await _customerService.Delete(id);
                if(result){
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound("Id Not Found !"); 
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request){
            var isExist = await _customerService.Validate(request.Id);
            if(!isExist){
                return NotFound("Id Not Found !");
            }
            try
            {
                UpdateCustomerRequestValidator validator = new UpdateCustomerRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _customerService.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request){
            try
            {
                CreateCustomerRequestValidator validator = new CreateCustomerRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _customerService.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}