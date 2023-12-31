#pragma checksum "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "351893ea96dc865c33f4683950e4d102bfc1831e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
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
#line 1 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\_ViewImports.cshtml"
using Endpoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\_ViewImports.cshtml"
using Endpoint.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
using E_commerce.Application.Services.Orders.Queries.GetUserOrders;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"351893ea96dc865c33f4683950e4d102bfc1831e", @"/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5becfe1756caed01bdbe500f776397c8b8352c5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetUserOrdersDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>سفارشات شما</h1>

<table style=""border:dashed"" class=""table table-responsive table-active table-bordered"">
    <thead>
        <tr style=""border:solid"">
            <th>شماره سفارش</th>
            <th>شماره فاکتور</th>
            <th>وضعیت سفارش</th>
            <th>محصولات در این سفارش</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 21 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr style=\"border:solid\">\r\n                <td>");
#nullable restore
#line 24 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
               Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
               Write(item.OrderState);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 26 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
               Write(item.RequestPayId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n                <td>\r\n                    <table>\r\n");
#nullable restore
#line 30 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
                         foreach (var detail in item.OrderDetails)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr style=\"border:outset\">\r\n                                <td> ");
#nullable restore
#line 33 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
                                Write(detail.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td> ");
#nullable restore
#line 34 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
                                Write(detail.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td> ");
#nullable restore
#line 35 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
                                Write(detail.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 37 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </table>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "D:\New folder\git source\New folder\E-commerce\Endpoint.Site\Views\Orders\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetUserOrdersDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
