using E_commerce.Application.Interface;
using E_commerce.Common.Dto;
using E_commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Reviews
{
    public interface IReviewService
    {
        ResultDto AddReview(long userId, long productId, string comment);
        ResultDto<List<ReviewDto>> GetReviewsByProductId(long productId);
        ResultDto<List<ReviewDto>> GetReviewsByUserId(long userId);
    }
    public class ReviewService : IReviewService
    {
        private readonly IDatabaseContext _context;

        public ReviewService(IDatabaseContext context)
        {
            _context = context;
        }
        // اضافه کردن نظر 
        public ResultDto AddReview(long userId, long productId, string comment)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                {
                    return ErrorResult("کاربر موردنظر یافت نشد");
                }

                var product = _context.Products.Find(productId);
                if (product == null)
                {
                    return ErrorResult("محصول موردنظر یافت نشد");

                }

                var review = CreateReview(userId, productId, comment);

                SaveReview(review);

                return SuccessResult("نظر شما با موفقیت ثبت شد");
            }
            catch (Exception ex)
            {
                return ErrorResult("خطا در ثبت نظر");


            }
        }
        //ایجاد نتیجه خطا
        private ResultDto ErrorResult(string errorMessage)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = errorMessage
            };
        }

        private ResultDto SuccessResult(string successMessage)
        {
            return new ResultDto
            {
                IsSuccess = true,
                Message = successMessage
            };
        }
        // ایحاد نیجه موفق
        private Review CreateReview(long userId, long productId, string comment)
        {
            return new Review
            {
                UserId = userId,
                ProductId = productId,
                Comment = comment,
                Date = DateTime.Now,
                Approved = false
            };
        }
        //اضافه کردن نظر به دیتابیس و ذخیره تغییرات
        private void SaveReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        
        //دریافت لیست نظرات بر اساس آیدی محصول
        public ResultDto<List<ReviewDto>> GetReviewsByProductId(long productId)
        {
            try
            {
                var reviews = _context.Reviews
                    .Include(r => r.User)
                    .Where(r => r.ProductId == productId)
                    .ToList();

                var reviewDtos = reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    UserName = r.User.FullName,
                    Comment = r.Comment,
                    Date = r.Date,
                    Approved = r.Approved
                }).ToList();

                return new ResultDto<List<ReviewDto>>()
                {
                    IsSuccess = true,
                    Data = reviewDtos
                };
            }
            catch (Exception ex)
            {
               
                return new ResultDto<List<ReviewDto>>()
                {
                    IsSuccess = false,
                    Message = "خطا در دریافت نظرات."
                };
            }
        }

        //دریافت لیست نظرات بر اساس آیدی کاربر
        public ResultDto<List<ReviewDto>> GetReviewsByUserId(long userId)
        {
            try
            {
                var reviews = _context.Reviews
                    .Where(r => r.UserId == userId)
                    .ToList();

                var reviewDtos = reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    UserName = r.User.FullName,
                    Comment = r.Comment,
                    Date = r.Date,
                    Approved = r.Approved
                }).ToList();

                return new ResultDto<List<ReviewDto>>()
                {
                    IsSuccess = true,
                    Data = reviewDtos
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<List<ReviewDto>>()
                {
                    IsSuccess = false,
                    Message = "خطا در دریافت نظرات."
                };
            }
        }

    }


    public class ReviewDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public bool Approved { get; set; }
    }
}
