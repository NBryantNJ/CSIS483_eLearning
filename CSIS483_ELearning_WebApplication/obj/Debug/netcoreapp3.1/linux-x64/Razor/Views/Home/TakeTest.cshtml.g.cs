#pragma checksum "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "364fe63a11bc96ec883ab99be7865517ded4de4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TakeTest), @"mvc.1.0.view", @"/Views/Home/TakeTest.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"364fe63a11bc96ec883ab99be7865517ded4de4b", @"/Views/Home/TakeTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a165cc956015dc632cb1b2433975d51652ba8f7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TakeTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CSIS483_ELearning_WebApplication.Models.TakeATestModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TakeTest/TakeTestLarge.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/TakeTest.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
  
    ViewData["Title"] = "Take Test";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b5079", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "364fe63a11bc96ec883ab99be7865517ded4de4b5341", async() => {
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
            WriteLiteral("\r\n\r\n\r\n\r\n<!--Testing contents-->\r\n");
#nullable restore
#line 13 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
 if (Model != null)
{
    int i = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"divTestContents\">\r\n        <h3 class=\"courseID\">");
#nullable restore
#line 18 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                        Write(Model[i].testID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <p>Answer each question to the best of your knowledge, then submit the test.</p>\r\n\r\n");
#nullable restore
#line 21 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
         foreach (TakeATestModel testModel in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p style=\"margin-top:50px;\">");
#nullable restore
#line 24 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                                   Write(Model[i].questionNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 24 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                                                             Write(Model[i].question);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <select class=\"form-control\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b9246", async() => {
#nullable restore
#line 26 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                   Write(Model[i].answerOption1);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b10475", async() => {
#nullable restore
#line 27 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                   Write(Model[i].answerOption2);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b11705", async() => {
#nullable restore
#line 28 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                   Write(Model[i].answerOption3);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b12935", async() => {
#nullable restore
#line 29 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"
                   Write(Model[i].answerOption4);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n");
#nullable restore
#line 31 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"

            i++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button class=\"btn btn-outline-success btnSubmitTest\">Submit</button>\r\n    </div>\r\n");
#nullable restore
#line 37 "C:\Users\Nicholas Bryant\source\repos\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\CSIS483_ELearning_WebApplication\Views\Home\TakeTest.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<!--JS FILE-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "364fe63a11bc96ec883ab99be7865517ded4de4b14897", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CSIS483_ELearning_WebApplication.Models.TakeATestModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
