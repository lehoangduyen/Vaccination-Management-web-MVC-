#pragma checksum "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ORG_CreateSchedule), @"mvc.1.0.view", @"/Views/ORG/CreateSchedule.cshtml")]
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
#line 1 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\_ViewImports.cshtml"
using Covid19_Vaccination_Infogate_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
using Covid19_Vaccination_Infogate_MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
using Covid19_Vaccination_Infogate_MVC.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b", @"/Views/ORG/CreateSchedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d6cf68f1de3d4ed5694007f3e39407c7f9dba19", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ORG_CreateSchedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Astra", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Corminaty", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Sputnik", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Vero", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Moderna", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
  
    Layout = "_LayoutFeaturePage";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
  
    Account account = SessionHelper.GetObjectFromJson<Account>(Context.Session, "AccountInfo");
    Organization org = SessionHelper.GetObjectFromJson<Organization>(Context.Session, "ORGProfile");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""/css/ORGCreateSchedule.css"">
<script src=""/js/ORGCreateSchedule.js""></script>

<div class=""holder-function-panel"">
    <div class=""function-panel"">
        <br>

        <div class=""panel-list-schedule"">

            <div class=""list-name orgid""");
            BeginWriteAttribute("id", " id=\"", 649, "\"", 661, 1);
#nullable restore
#line 20 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
WriteAttributeValue("", 654, org.Id, 654, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
                                                 Write(org.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

            <div class=""holder"">
                <div class=""panel-update-schedule"" id=""panel-update-schedule"">
                    <div class=""title"">TẠO LỊCH TIÊM CHỦNG</div>
                    <div class=""container"">
                        <div class=""container-select-date-vaccine"">
                            <label for=""schedule-date""");
            BeginWriteAttribute("class", " class=\"", 1030, "\"", 1038, 0);
            EndWriteAttribute();
            WriteLiteral(">Ngày tạo lịch tiêm</label>\r\n                            <input id=\"schedule-date\" type=\"date\"");
            BeginWriteAttribute("min", " min=\"", 1133, "\"", 1154, 1);
#nullable restore
#line 28 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\CreateSchedule.cshtml"
WriteAttributeValue("", 1139, DateTime.Today, 1139, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                            <label for=\"vaccine\"");
            BeginWriteAttribute("class", " class=\"", 1208, "\"", 1216, 0);
            EndWriteAttribute();
            WriteLiteral(">Loại vaccine</label>\r\n                            <select type=\"text\" name=\"vaccine\" id=\"vaccine\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b7808", async() => {
                WriteLiteral("AstraZeneca");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b9004", async() => {
                WriteLiteral("Corminaty (Pfizer)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b10207", async() => {
                WriteLiteral("Sputnik V");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b11402", async() => {
                WriteLiteral("Verro Cell");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d48e2f5092a67f944a8b9dfa5139b7672b7ba6b12598", async() => {
                WriteLiteral("Moderna");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </select>\r\n                            <label for=\"serial\"");
            BeginWriteAttribute("class", " class=\"", 1791, "\"", 1799, 0);
            EndWriteAttribute();
            WriteLiteral(">Số lô vaccine</label>\r\n                            <input id=\"serial\" type=\"text\">\r\n                        </div>\r\n                        <div class=\"container-update-value\">\r\n                            <label for=\"limit-day\"");
            BeginWriteAttribute("class", " class=\"", 2029, "\"", 2037, 0);
            EndWriteAttribute();
            WriteLiteral(">Giới hạn đăng ký buổi sáng</label>\r\n                            <input id=\"limit-day\" type=\"number\" min=\"0\">\r\n\r\n                            <label for=\"limit-noon\"");
            BeginWriteAttribute("class", " class=\"", 2202, "\"", 2210, 0);
            EndWriteAttribute();
            WriteLiteral(">Giới hạn đăng ký buổi chiều</label>\r\n                            <input id=\"limit-noon\" type=\"number\" min=\"0\">\r\n\r\n                            <label for=\"limit-night\"");
            BeginWriteAttribute("class", " class=\"", 2378, "\"", 2386, 0);
            EndWriteAttribute();
            WriteLiteral(@">Giới hạn đăng ký buổi tối</label>
                            <input id=""limit-night"" type=""number"" min=""0"">
                        </div>
                    </div>
                    <button class=""btn-medium-bordered"" id=""btn-confirm-create-schedule"">Xác nhận</button>

                </div>
            </div>
        </div>

    </div>
</div>
    </div>
<!-- END FUNCTION PANEL -->
<br>");
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
