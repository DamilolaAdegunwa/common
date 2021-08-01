#pragma checksum "C:\Users\damil\source\repos\common\Engine\SignalrClient.WebApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cd4fe223cac57e6f72ae6a4f6a62a4bdbe1f7c5"
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
#line 1 "C:\Users\damil\source\repos\common\Engine\SignalrClient.WebApplication\Views\_ViewImports.cshtml"
using SignalrClient.WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\damil\source\repos\common\Engine\SignalrClient.WebApplication\Views\_ViewImports.cshtml"
using SignalrClient.WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cd4fe223cac57e6f72ae6a4f6a62a4bdbe1f7c5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"897b69ca2dc08d8ebdca45293ebd62f61012e29f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\damil\source\repos\common\Engine\SignalrClient.WebApplication\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Client 1";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Client 1.</p>
    <button class=""btn btn-default"" onclick=""send();"">Send Message</button>
</div>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/3.1.7/signalr.min.js""></script>
<script>
    /*
    {
          ""username"": ""dammy.adegunwa@gmail.com"",
          ""password"": ""password""
    }
    user id = 10044
     */
    const connection = new signalR.HubConnectionBuilder()
        //.withUrl(""/chathub"")
        .withUrl(""https://localhost:44300/ChatHub"",
            { accessTokenFactory: () => `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEwMDQ0IiwibmFtZSI6ImRhbW15LmFkZWd1bndhQGdtYWlsLmNvbSIsImVtYWlsIjoiZGFtbXkuYWRlZ3Vud2FAZ21haWwuY29tIiwibmJmIjoxNjI3NzU3Nzg1LCJleHAiOjE2Mjc5Mzc3ODUsImlzcyI6IkVraUhpcmUuQXBpIiwiYXVkIjoiRWtpSGlyZS5XZWIifQ.kMUOlSU_sqaXKIEtX8qGRNHViHoW7F18GkanUZTr3UI` })
        .configureLogging(signalR.LogLevel.Information)
        .withAutomaticReconnect()
        .build();

   ");
            WriteLiteral(@" connection.on(""receiveMessage"", (message) => {
        console.log(""from receive message::"", message)
    });

    
    async function start() {
        try {
            await connection.start();
            console.log(""SignalR Connected."");
        } catch (err) {
            console.log(""HubConnectionBuilder failed to start! "", err);
            setTimeout(start, 5000);
        }
    };

    connection.onreconnecting(error => {
        console.log(""onreconnecting:: "", error);
    });

    connection.onreconnected(connectionId => {
        console.log(""onreconnected:: "", connectionId);
    });

    connection.onclose(async () => {
        console.log(""onclose called"");
        await start();
    });

    // Start the connection.
    start();
    async function send() {
        try {
            var message = {
                ""senderId"": 10044,
                ""recipientId"": 10054,
                ""text"": ""client_1 to client_2"",
            };
            await connect");
            WriteLiteral("ion.invoke(\"SendMessage\", message);\r\n        } catch (err) {\r\n            console.error(\"SendMessage failed! \", err);\r\n        }\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591