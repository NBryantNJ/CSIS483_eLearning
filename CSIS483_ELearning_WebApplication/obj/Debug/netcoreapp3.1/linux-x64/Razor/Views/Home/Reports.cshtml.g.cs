#pragma checksum "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8347e1c0113dd19e0c76d2812cc3781cad36a40d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reports), @"mvc.1.0.view", @"/Views/Home/Reports.cshtml")]
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
#line 1 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\_ViewImports.cshtml"
using CSIS483_ELearning_WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\_ViewImports.cshtml"
using CSIS483_ELearning_WebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8347e1c0113dd19e0c76d2812cc3781cad36a40d", @"/Views/Home/Reports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a165cc956015dc632cb1b2433975d51652ba8f7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Reports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CSIS483_ELearning_WebApplication.Models.RetrieveUsersReportModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Reports/ReportsLarge.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
  
    ViewData["Title"] = "Reports";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8347e1c0113dd19e0c76d2812cc3781cad36a40d4909", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8347e1c0113dd19e0c76d2812cc3781cad36a40d5171", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"divTableWrapper\">\r\n    <h5>OnBoard eTraining Testing Results</h5>\r\n");
#nullable restore
#line 15 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
     if (Context.Session.GetString("username") != null) //If user is signed in
    {
        //If user has previous reports
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
         if (Model.Count != 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""reportsTable"">
                <tr>
                    <th>Course Name</th>
                    <th>Assigned by</th>
                    <th>Date asssigned</th>
                    <th>Date taken</th>
                    <th>Grade</th>
                </tr>
");
#nullable restore
#line 28 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                 for (int i = 0; i < Model.Count; i++)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                       Write(Model[i].courseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                       Write(Model[i].assignedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                       Write(Model[i].dateAssigned);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                       Write(Model[i].dateTaken);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                       Write(Model[i].grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 38 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n");
#nullable restore
#line 40 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
        }
        //If user is signed in with no previous reports
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"divSignedInButNoReports\">\r\n                <h5>No reports available</h5>\r\n                <p>You haven\'t completed any courses yet.</p>\r\n            </div>\r\n");
#nullable restore
#line 48 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
         
    }
    //If user is not signed in
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"divNotSignedIn\">\r\n            <h5>No report available</h5>\r\n            <p>Login to see your previous reports.</p>\r\n            <button class=\"btn btn-dark divLogin\">Login</button>\r\n        </div>\r\n");
#nullable restore
#line 58 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\Reports.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CSIS483_ELearning_WebApplication.Models.RetrieveUsersReportModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
