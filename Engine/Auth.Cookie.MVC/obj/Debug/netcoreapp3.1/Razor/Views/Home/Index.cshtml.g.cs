#pragma checksum "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e7d43eac92b2ff2888b4c59212d35c288767e6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\_ViewImports.cshtml"
using Auth.Cookie.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\_ViewImports.cshtml"
using Auth.Cookie.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e7d43eac92b2ff2888b4c59212d35c288767e6c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a736cf21da98c04c020f9f9a29b62359822c39c6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    HtmlString str = new HtmlString("<b>(2) Hello Boss</b>");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n    ");
#nullable restore
#line 9 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml"
Write(Html.Raw("<b>(1) Hello Boss</b>"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml"
Write(str);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 11 "C:\Users\damil\source\repos\C#\common\Engine\Auth.Cookie.MVC\Views\Home\Index.cshtml"
Write(ViewBag.htm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n");
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
