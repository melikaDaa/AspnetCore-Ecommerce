#pragma checksum "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d63a941f3159b92bdba34f846e381ab979f9c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_UserPanel), @"mvc.1.0.view", @"/Views/Authentication/UserPanel.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\_ViewImports.cshtml"
using Endpoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\_ViewImports.cshtml"
using Endpoint.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
using E_commerce.Application.Services.Reviews;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3d63a941f3159b92bdba34f846e381ab979f9c5", @"/Views/Authentication/UserPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5becfe1756caed01bdbe500f776397c8b8352c5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Authentication_UserPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ReviewDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
  
    ViewData["Title"] = "UserPanel";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-main"">
    <div class=""d-block"">
        <section class=""profile-home"">
            <div class=""col-lg"">
                <div class=""post-item-profile order-1 d-block"">
                    <div class=""col-lg-3 col-md-3 col-xs-12 pr"">
                        <div class=""sidebar-profile sidebar-navigation"">
                            <section class=""profile-box"">
                                <header class=""profile-box-header-inline"">
                                    <div class=""profile-avatar user-avatar profile-img"">
                                        <img src=""assets/images/man.png"">
                                    </div>
                                </header>
                                <footer class=""profile-box-content-footer"">
                                    <span class=""profile-box-nameuser""> ");
#nullable restore
#line 23 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
                                                                   Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>         
                                    <span class=""profile-box-registery-date"">عضویت در سایت 2 پیش</span>
                                    <span class=""profile-box-phone"">شماره همراه : *******0991</span>
                                    <div class=""profile-box-tabs"">
                                        <a href=""#"" class=""profile-box-tab-sign-out""><i class=""mdi mdi-logout-variant""></i>خروج از حساب</a>
                                    </div>
                                </footer>
                            </section>
                            <section class=""profile-box"">
                                <ul class=""profile-account-navs"">
                                    <li class=""profile-account-nav-item navigation-link-dashboard"">
                                        <a href=""#"" class=""active"">
                                            <i class=""mdi mdi-account-outline""></i>
                                            پروفایل
                             ");
            WriteLiteral("           </a>\r\n                                    </li>\r\n                                    <li class=\"profile-account-nav-item navigation-link-dashboard\">\r\n                                        <a href=\"/Orders\"");
            BeginWriteAttribute("class", " class=\"", 2354, "\"", 2362, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""mdi mdi-cart""></i>
                                            همه سفارش ها
                                        </a>
                                    </li>
                                    <li class=""profile-account-nav-item navigation-link-dashboard"">
                                        <a href=""#""");
            BeginWriteAttribute("class", " class=\"", 2739, "\"", 2747, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""mdi mdi-heart""></i>
                                            لیست علاقه مندی
                                        </a>
                                    </li>
                                    <li class=""profile-account-nav-item navigation-link-dashboard"">
                                        <a href=""#""");
            BeginWriteAttribute("class", " class=\"", 3128, "\"", 3136, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""mdi mdi-map-outline""></i>
                                            آدرس ها
                                        </a>
                                    </li>
                                    <li class=""profile-account-nav-item navigation-link-dashboard"">
                                        <a href=""#"" >
                                            <i class=""mdi mdi-email-open-outline""></i>
                                            نظرات
                                       
                                        </a>
                                    </li>

                                    <li class=""profile-account-nav-item navigation-link-dashboard"">
                                        <a href=""#""");
            BeginWriteAttribute("class", " class=\"", 3942, "\"", 3950, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <i class=""mdi mdi-tooltip-text-outline""></i>
                                            اطلاعات حساب
                                        </a>
                                    </li>
                                </ul>
                            </section>
                        </div>
                    </div>
                    <div class=""col-lg-9 col-md-9 col-xs-12 pl"" >
                        <div class=""profile-content"">
                            <div class=""profile-stats"">
                                <table class=""table table-profile"">
                                    <tbody>
                                        <tr>
                                            <td class=""w-50"">
                                                <div class=""title"">نام و نام خانوادگی:</div>
                                                <div class=""value""> ");
#nullable restore
#line 83 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
                                                               Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                            </td>
                                            <td>
                                                <div class=""title"">پست الکترونیک :</div>
                                                <div class=""value"">info@digismart.com</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class=""title"">شماره تلفن همراه:</div>
                                                <div class=""value"">*******0991</div>
                                            </td>
                                            <td>
                                                <div class=""title"">تاریخ عضویت:</div>
                                                <div class=""value"">۱۳۹۹/۰۱/۱۲</div>
                                            </td>
                                    ");
            WriteLiteral(@"    </tr>
                                        <tr>
                                            <td>
                                                <div class=""title""> دریافت خبرنامه :</div>
                                                <div class=""value"">بله</div>
                                            </td>
                                            <td>
                                                <div class=""title""> کد ملی :</div>
                                                <div class=""value"">-</div>
                                            </td>
                                            <br />
                                     <td>
                                                <div class=""title"">  نظرات :</div>
                                                <div class=""value"">   ");
#nullable restore
#line 112 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
                                                                 Write(await Component.InvokeAsync("Review",Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class=""profile"">
                                    <ul class=""mb-0"">
                                        <li class=""profile-item"">
                                            <div class=""title"">نام و نام خانوادگی:</div>
                                            <div class=""value""> ");
#nullable restore
#line 121 "D:\New folder\Bugeto (online shop)\E-commerce\Endpoint.Site\Views\Authentication\UserPanel.cshtml"
                                                           Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div class=""title"">پست الکترونیک :</div>
                                            <div class=""value"">info@digismart.com</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div class=""title"">شماره تلفن همراه:</div>
                                            <div class=""value"">*******0991</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div class=""title"">تاریخ عضویت:</div>
                                            <div class=""value"">۱۳۹۹/۰۱/۱۲</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div cl");
            WriteLiteral(@"ass=""title""> دریافت خبرنامه :</div>
                                            <div class=""value"">بله</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div class=""title""> کد ملی :</div>
                                            <div class=""value"">-</div>
                                        </li>
                                        <li class=""profile-item"">
                                            <div class=""title"">  نظرات :</div>
                                            <div class=""value"">-</div>
                                        </li>

                                    </ul>
                                </div>
                          
                                <div class=""profile-edit-action"">
                                    <a href=""#"" class=""link-spoiler-edit btn btn-secondary"">ویرایش اطلاعات</a>
                                </div>
  ");
            WriteLiteral("                              \r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n\r\n        \r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ReviewDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591