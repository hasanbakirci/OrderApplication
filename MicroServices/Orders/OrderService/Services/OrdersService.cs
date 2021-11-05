using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.OrderRepository;
using OrderService.Dtos.Requests;
using OrderService.Dtos.Responses;
using OrderService.Extensions;

namespace OrderService.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRespository;
        private readonly IMapper _mapper;

        public OrdersService(IOrderRepository orderRespository, IMapper mapper)
        {
            _orderRespository = orderRespository;
            _mapper = mapper;
        }

        public async Task<bool> ChangeStatus(Guid id, string status)
        {
            return await _orderRespository.ChangeStatus(id,status);
        }

        public async Task<Guid> Create(CreateOrderRequest request)
        {
            var order = request.ConvertToOrder(_mapper);
            var id = await _orderRespository.Create(order);
            return id;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _orderRespository.Delete(id);
        }

        public async Task<IEnumerable<OrderResponse>> Get()
        {
            var orders = await _orderRespository.Get();
            var response = orders.ConvertToCustomerListResponse(_mapper);
            return response;
        }

        public async Task<OrderResponse> GetById(Guid id)
        {
            var order = await _orderRespository.GetById(id);
            var response = order.ConvertToOrderResponse(_mapper);
            return response; 
        }

        public async Task<IEnumerable<OrderResponse>> GetByCustomerId(Guid id)
        {
            var orders = await _orderRespository.GetByCustomerId(id);
            var response = orders.ConvertToCustomerListResponse(_mapper);
            return response;
        }

        public async Task<bool> Update(UpdateOrderRequest request)
        {
            var order = request.ConvertToOrder(_mapper);
            return await _orderRespository.Update(order);
        }

        public async Task<bool> OrderIsExist(Guid id){
            return await _orderRespository.OrderIsExist(id);
        }
    }
}