using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Carts;
using E_commerce.Domain.Entities.Finances;
using E_commerce.Domain.Entities.Orders;
using E_commerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderSericeDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDatabaseContext _context;
        public AddNewOrderService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewOrderSericeDto request)
        {


            var user = GetUserById(request.UserId);
            var requestPay = GetRequestPayById(request.RequestPayId);
            var cart = GetCartWithItems(request.CartId);

            UpdateRequestPayForPayment(requestPay);
            MarkCartAsFinished(cart);
            CreateOrderAndOrderDetails(user, requestPay, cart);

            return CreateSuccessResult();


        }
        //یافتن کاربر بر اساس آیدی
        private User GetUserById(long userId)
        {
            return _context.Users.Find(userId);
        }
        //یافتن درخواست پرداخت بر اساس آیدی
        private RequestPay GetRequestPayById(long requestPayId)
        {
            return _context.RequestPays.Find(requestPayId);
        }
        //دریافت سبدخرید محصولات بر اساس آیدی
        private Cart GetCartWithItems(long cartId)
        {
            return _context.Carts.Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(p => p.Id == cartId);
        }
        // به‌روزرسانی وضعیت درخواست پرداخت برای پرداخت
        private void UpdateRequestPayForPayment(RequestPay requestPay)
        {
            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
        }
        // نشان دادن سبد خرید به عنوان پرداخت‌شده
        private void MarkCartAsFinished(Cart cart)
        {

            cart.Finished = true;
        }
        // ایجاد سفارش و جزئیات سفارش
        private void CreateOrderAndOrderDetails(User user, RequestPay requestPay, Cart cart)
        {
            var order = CreateOrder(user, requestPay);

            _context.Orders.Add(order);

            var orderDetails = CreateOrderDetails(cart.CartItems, order);

            _context.OrderDetails.AddRange(orderDetails);

            _context.SaveChanges();
        }
        //ایجاد سفارش
        private Order CreateOrder(User user, RequestPay requestPay)
        {
            return new Order
            {
                Address = "",
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user
            };
        }
        // ایجاد لیست جزئیات سفارش
        private List<OrderDetail> CreateOrderDetails(IEnumerable<CartItem> cartItems, Order order)
        {
            var orderDetails = new List<OrderDetail>();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product
                };
                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }
        // ایجاد نتیجه‌ی موفقیت
        private ResultDto CreateSuccessResult()
        {
            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }

    }
    public class RequestAddNewOrderSericeDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }

    }
}
