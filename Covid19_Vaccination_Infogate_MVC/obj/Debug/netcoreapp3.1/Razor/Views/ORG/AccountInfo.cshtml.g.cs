#pragma checksum "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c8215334403eb058225210903e384d6f32aa85b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ORG_AccountInfo), @"mvc.1.0.view", @"/Views/ORG/AccountInfo.cshtml")]
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
#line 4 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
using Covid19_Vaccination_Infogate_MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
using Covid19_Vaccination_Infogate_MVC.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c8215334403eb058225210903e384d6f32aa85b", @"/Views/ORG/AccountInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d6cf68f1de3d4ed5694007f3e39407c7f9dba19", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ORG_AccountInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CitizenAccountInfo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ORGAccountInfo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ORGAccountUpdate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
  
    Layout = "_LayoutFeaturePage";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
  
    Account account = SessionHelper.GetObjectFromJson<Account>(Context.Session, "AccountInfo");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6c8215334403eb058225210903e384d6f32aa85b5405", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c8215334403eb058225210903e384d6f32aa85b6520", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c8215334403eb058225210903e384d6f32aa85b7559", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n \r\n<div class=\"holder-function-panel\">\r\n    <!-- MENU -->\r\n");
#nullable restore
#line 17 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
   Write(await Component.InvokeAsync("ViewFunctionMenu"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
                                                        ;
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!-- END MENU -->
    <!-- FUNCTIONAL PANEL -->
    <div class=""function-panel"">
        <div class=""accinfo-panel"">
            <div class=""frame"">
                <div class=""account"">
                    <br>
                    <p>Tài khoản</p>
                    <br>
                    <label for=""id"">Mã đơn vị tiêm chủng</label><br>
                    <input type=""text"" name=""id"" required");
            BeginWriteAttribute("value", " value=\"", 970, "\"", 995, 1);
#nullable restore
#line 29 "D:\Lychthac\Covid19_Vaccination_Infogate_MVC\Views\ORG\AccountInfo.cshtml"
WriteAttributeValue("", 978, account.Username, 978, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled><br>
                    <hr>
                    <div class=""message msg1""></div>
                    <br>

                    <label for=""password"">Nhập mật khẩu hiện tại</label><br>
                    <input type=""password"" name=""password"" required");
            BeginWriteAttribute("value", " value=\"", 1265, "\"", 1273, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>
                    <hr>
                    <div class=""message msg2""></div>
                </div>
            </div>

            <div class=""frame"">
                <div class=""change-pass"">
                    <br>
                    <p>Đổi mật khẩu</p>
                    <br>
                    <label for=""new-password"">Mật khẩu mới</label><br>
                    <input type=""password"" name=""new-password"" required");
            BeginWriteAttribute("value", " value=\"", 1719, "\"", 1727, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>
                    <hr>
                    <div class=""message msg1""></div>
                    <br>

                    <label for=""repeat-new-password"">Nhập mật khẩu mới</label><br>
                    <input type=""password"" name=""repeat-new-password"" required");
            BeginWriteAttribute("value", " value=\"", 2005, "\"", 2013, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>
                    <hr>
                    <div class=""message msg2""></div>
                </div>
            </div>
        </div>

        <div class=""group_btn"">
            <button class=""btn-medium-filled"" id=""update-account-info"">Cập nhật</button>
            <button class=""btn-medium-bordered"" id=""cancel-update-account-info"">Hủy bỏ</button>
        </div>
    </div>
</div>

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
