using System;
using E_commerce.Application.Interface;
using E_commerce.Application.Services.Reviews;
using E_commerce.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YourNamespace.Tests 
{
    [TestClass]
    public class ReviewServiceTests
    {
        private FakeDatabaseContext _context;
 
        private ReviewService _reviewService;

      

        [TestInitialize]
        public void Initialize()
        {
            _context = new FakeDatabaseContext();
            _reviewService = new ReviewService(_context); 
        }

        [TestMethod]
        public void AddReview_ValidUserAndProduct_ReturnsSuccessResult()
        {
            // Arrange
            var userId = 1;
            var productId = 123;
            var comment = "This is a test comment";

            // Act
            var result = _reviewService.AddReview(userId, productId, comment);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("نظر با موفقیت ثبت شد.", result.Message);
        }

        // موارد دیگر تست‌ها می‌توانند اضافه شوند
    }
}
