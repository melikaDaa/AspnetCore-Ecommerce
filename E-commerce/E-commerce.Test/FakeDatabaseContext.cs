using E_commerce.Application.Interface;
using E_commerce.Domain.Entities.Products;
using E_commerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Test
{
    public class FakeDatabaseContext : IDatabaseContext
    {
        private List<User> _users = new List<User>();
        private List<Product> _products = new List<Product>();
        private List<Review> _reviews = new List<Review>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User FindUser(long userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product FindProduct(long productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public Review FindReview(long reviewId)
        {
            return _reviews.FirstOrDefault(r => r.Id == reviewId);
        }

        // ... سایر توابع مرتبط با دیتابیس
    }

}
