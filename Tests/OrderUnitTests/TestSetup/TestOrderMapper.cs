using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using OrderService.Dtos.Responses;

namespace OrderUnitTests.TestSetup
{
    public static class TestOrderMapper
    {
        // Mapping
        public static IEnumerable<OrderResponse> ConvertToListDto(this List<Order> orders)
        {
            List<OrderResponse> orderResponses = new List<OrderResponse>();
            orders.ToList().ForEach(order => orderResponses.Add(new OrderResponse
            {
                Id = order.Id,
                Price = order.Price,
                Quantity = order.Quantity,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                CustomerId = order.CustomerId,
                AddressResponse = order.AddressId.ToString(),
                ProductResponse = order.ProductId.ToString()
            }));
            return orderResponses;
        }

        public static OrderResponse ConvertToDto(this Order order)
        {
            OrderResponse orderRespons = new OrderResponse();
            orderRespons = new OrderResponse
            {
                Id = order.Id,
                Price = order.Price,
                Quantity = order.Quantity,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                CustomerId = order.CustomerId,
                AddressResponse = order.AddressId.ToString(),
                ProductResponse = order.ProductId.ToString()
            };
            return orderRespons;
        }
    }
}