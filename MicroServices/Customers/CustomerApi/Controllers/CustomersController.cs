using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Dtos.Requests;
using CustomerService.Services;
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
                var customer = await _customerService.Get(id);
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
            var isValidate = await _customerService.Validate(request.id);
            if(isValidate){
                if(ModelState.IsValid){
                    var result = await _customerService.Update(request);
                    return Ok(result); 
                }
                return BadRequest(ModelState);
            }
            return NotFound("Id Not Found !");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request){
            if(ModelState.IsValid){
                var result = await _customerService.Create(request);
                return Ok(result);  
            }
            return BadRequest(ModelState);
        }
    }
}