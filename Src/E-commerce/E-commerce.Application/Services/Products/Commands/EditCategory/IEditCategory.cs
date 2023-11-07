using E_commerce.Application.Interface;
using E_commerce.Application.Services.Users.Commands.EditUser;
using E_commerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.Products.Commands.EditCategory
{
    public interface IEditCategory
    {
        ResultDto Execute(RequestEditcategoryDto request);

    }
    public class EditCategory : IEditCategory
    {
        private readonly IDatabaseContext _context;

        public EditCategory(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditcategoryDto request)
        {
            var Cat = _context.Categories.Find(request.Id);
            if (Cat == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            Cat.Name = request.name;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش دسته بندی انجام شد"
            };
        }
    }
    public class RequestEditcategoryDto
    {
        public long Id { get; set; }
        public string name { get; set; }
    }
}
