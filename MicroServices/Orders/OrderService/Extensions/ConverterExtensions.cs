using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using OrderService.Dtos.Requests;
using OrderService.Dtos.Responses;

namespace OrderService.Extensions
{
    public static class ConverterExtensions
    {
        public static IEnumerable<OrderResponse> ConvertToCustomerListResponse(this IEnumerable<Order> orders, IMapper mapper){
            var responses = mapper.Map<IEnumerable<OrderResponse>>(orders);
            return responses;
        }
        public static OrderResponse ConvertToOrderResponse(this Order order, IMapper mapper){
            var response = mapper.Map<OrderResponse>(order);
            return response;
        }
        public static Order ConvertToOrder(this CreateOrderRequest createOrderRequest, IMapper mapper){
            return mapper.Map<Order>(createOrderRequest);
        }
        public static Order ConvertToOrder(this UpdateOrderRequest updateOrderRequest, IMapper mapper){
            return mapper.Map<Order>(updateOrderRequest);
        }
    }
}