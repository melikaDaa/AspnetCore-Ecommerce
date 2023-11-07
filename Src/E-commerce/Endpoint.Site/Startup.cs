using E_commerce.Application.Interface;
using E_commerce.Application.Interface.FacadPattern;
using E_commerce.Application.Services.Carts;
using E_commerce.Application.Services.Common.Queries.GetCategory;
using E_commerce.Application.Services.Common.Queries.GetMenuItem;
using E_commerce.Application.Services.Fainances.Commands.AddRequestPay;
using E_commerce.Application.Services.Fainances.Queries.GetRequestPayService;
using E_commerce.Application.Services.Orders.Commands.AddNewOrder;
using E_commerce.Application.Services.Orders.Queries.GetOrdersForAdmin;
using E_commerce.Application.Services.Orders.Queries.GetUserOrders;
using E_commerce.Application.Services.Products.Commands.EditCategory;
using E_commerce.Application.Services.Products.FacadPattern;
using E_commerce.Application.Services.Reviews;
using E_commerce.Application.Services.Users.Commands.EditUser;
using E_commerce.Application.Services.Users.Commands.RegisterUser;
using E_commerce.Application.Services.Users.Commands.RemoveUser;
using E_commerce.Application.Services.Users.Commands.UserLogin;
using E_commerce.Application.Services.Users.Commands.UserSatusChange;
using E_commerce.Application.Services.Users.Queries.GetRole;
using E_commerce.Application.Services.Users.Queries.GetUser;
using E_commerce.Common.Roles;
using E_commerce.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });


            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetRoleService, GetRoleService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IEditCategory, EditCategory>();
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService, GetRequestPayService>();
            services.AddScoped<IReviewService, ReviewService>();
            
          services.AddScoped<IAddNewOrderService, AddNewOrderService>();
            
           services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
            
           services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();


            //FacadInject
            services.AddScoped<IProductFacad, ProductFacad>();

            //------------
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();

            string contectionString = @"Data Source=.; Initial Catalog=E-Commerce; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option => option.UseSqlServer(contectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
