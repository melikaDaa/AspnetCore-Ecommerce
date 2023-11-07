using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Orders.Queries.GetUserOrders
{
    public interface IGetUserOrdersService
    {
        ResultDto<List<GetUserOrdersDto>> Execute(long userId);

    }
    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDatabaseContext _context;

        public GetUserOrdersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUserOrdersDto>> Execute(long userId)
        {
            var orders = _context.Orders
                 .Include(p => p.OrderDetails)
                 .ThenInclude(p => p.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(p => p.Id).ToList().Select(p=> new GetUserOrdersDto{
                    OrderId=p.Id,
                    OrderState=p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailsDto
                    {
                        Count = o.Count,
                        OrderDetailId = o.Id,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };



        }
    }
    public class GetUserOrdersDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }
    public class OrderDetailsDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

    }
}
