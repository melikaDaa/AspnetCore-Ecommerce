using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Carts;
using E_commerce.Domain.Entities.Products;
using E_commerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(long ProductId, Guid BrowserId);
        ResultDto RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDto<CartDto> GetMyCart(Guid BrowserId, long? UserId);
        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);
    }
    public class CartService : ICartService
    {
        private readonly IDatabaseContext _context;

        public CartService(IDatabaseContext context)
        {
            _context = context;
        }
        //اضافه کردن تعداد مورد در سبد خرید
        public ResultDto Add(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        //افزودن به سبد خرید
        public ResultDto AddToCart(long ProductId, Guid BrowserId)
        {

            var cart = GetActiveCart(BrowserId);

            var product = _context.Products.Find(ProductId);

            UpdateCartItem(cart, product);



            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
            };
        }
        // دریافت سبد خرید فعال
        private Cart GetActiveCart(Guid browserId)
        {
            var cart = _context.Carts.Where(p => p.BrowserId == browserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                cart = CreateNewCart(browserId);
            }
            return cart;
        }
        // ایجاد یک سبد خرید جدید
        private Cart CreateNewCart(Guid browserId)
        {
            var newCart = new Cart
            {
                Finished = false,
                BrowserId = browserId,
            };
            _context.Carts.Add(newCart);
            _context.SaveChanges();

            return newCart;
        }
        // به‌روزرسانی محصول در سبد خرید
        private void UpdateCartItem(Cart cart, Product product)
        {
            var cartItem = _context.CartItems.Where(p => p.ProductId == product.Id && p.CartId == cart.Id).FirstOrDefault();

            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                var newCartItem = CreateNewCartItem(cart, product);

                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }
        }
        // ایجاد یک مورد سبد خرید جدید
        private CartItem CreateNewCartItem(Cart cart, Product product)
        {
            return new CartItem
            {
                Cart = cart,
                Count = 1,
                Price = product.Price,
                Product = product,
            };
        }

        //دریافت سبد خرید کاربر
        public ResultDto<CartDto> GetMyCart(Guid BrowserId, long? UserId)
        {
            try
            {
                var cart = _context.Carts
                    .Include(p => p.CartItems)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.ProductImages)
                    .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                    .OrderByDescending(p => p.Id)
                    .FirstOrDefault();

                if (cart == null)
                {
                    return new ResultDto<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            CartItems = new List<CartItemDto>()
                        },
                        IsSuccess = false,
                    };
                }

                if (UserId != null)
                {
                    var user = _context.Users.Find(UserId);
                    cart.User = user;
                    _context.SaveChanges();
                }



                return new ResultDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.CartItems.Count(),
                        SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        CartId = cart.Id,
                        CartItems = cart.CartItems.Select(p => new CartItemDto
                        {
                            Count = p.Count,
                            Price = p.Price,
                            Product = p.Product.Name,
                            Id = p.Id,
                            Images = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                        }).ToList(),
                    },
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //کم کردن تعداد  محصولات در سبد خرید
        public ResultDto LowOff(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
        //حذف کردن محصول از سبد خرید
        public ResultDto RemoveFromCart(long ProductId, Guid BrowserId)
        {
            var cartitem = _context.CartItems.Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefault();
            if (cartitem != null)
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }
    }
    public class CartDto
    {
        public long CartId { get; set; }
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Images { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
