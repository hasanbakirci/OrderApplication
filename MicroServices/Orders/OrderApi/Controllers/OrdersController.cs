using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos.Requests;
using OrderService.Services;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.Get();
            return Ok(orders);
        }
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var isExist = await _orderService.OrderIsExist(id);
            if (isExist)
            {
                var order = await _orderService.GetById(id);
                return Ok(order);
            }
            return NotFound("Id Not Found !");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isExist = await _orderService.OrderIsExist(id);
            if (isExist)
            {
                var result = await _orderService.Delete(id);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound("Id Not Found !");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request)
        {
            var isExist = await _orderService.OrderIsExist(request.Id);
            if (!isExist){
                return NotFound("Id Not Found !");
            }
            try
            {
                UpdateOrderRequestValidator validator = new UpdateOrderRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _orderService.Update(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(Guid id, string status)
        {
            var isExist = await _orderService.OrderIsExist(id);
            if (isExist)
            {
                var result = await _orderService.ChangeStatus(id, status);
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound("Id Not Found !");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            try
            {
                CreateOrderRequestValidator validate = new CreateOrderRequestValidator();
                validate.ValidateAndThrow(request);
                var result = await _orderService.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("SearchCustomerId/{id}")]
        public async Task<IActionResult> GetByCustomerId(Guid id)
        {
            var orders = await _orderService.GetByCustomerId(id);
            if (orders.Count() > 0)
            {
                return Ok(orders);
            }
            return NotFound("Id Not Found !");
        }
    }
}