#pragma checksum "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5aa3f2ae26c2832c4770f45ecfe2e410f6d0a6bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_List), @"mvc.1.0.view", @"/Views/User/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/List.cshtml", typeof(AspNetCore.Views_User_List))]
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
#line 1 "F:\dacheng\workspace\store\store\store\Views\_ViewImports.cshtml"
using store;

#line default
#line hidden
#line 2 "F:\dacheng\workspace\store\store\store\Views\_ViewImports.cshtml"
using store.Models;

#line default
#line hidden
#line 1 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
using Model.Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aa3f2ae26c2832c4770f45ecfe2e410f6d0a6bd", @"/Views/User/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566700498a609f6e2f7139cc0b245fed22787aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_User_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/Paging.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 362, true);
            WriteLiteral(@"<style>
    .table tbody tr td {
        vertical-align: middle;
    }
</style>

<div class=""panel"">


    <table class=""table table-striped"">
        <tr>
            <td>编号</td>
            <td>用户账号</td>
            <td>用户名</td>
            <td>性别</td>
            <td>年龄</td>
            <td>用户等级</td>
            <td>操作</td>
        </tr>
");
            EndContext();
#line 21 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
         foreach (T_User user in ViewBag.list)
        {

#line default
#line hidden
            BeginContext(442, 54, true);
            WriteLiteral("            <tr>\r\n                <td class=\"td-text\">");
            EndContext();
            BeginContext(497, 7, false);
#line 24 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
                               Write(user.id);

#line default
#line hidden
            EndContext();
            BeginContext(504, 43, true);
            WriteLiteral("</td>\r\n                <td class=\"td-text\">");
            EndContext();
            BeginContext(548, 12, false);
#line 25 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
                               Write(user.account);

#line default
#line hidden
            EndContext();
            BeginContext(560, 43, true);
            WriteLiteral("</td>\r\n                <td class=\"td-text\">");
            EndContext();
            BeginContext(604, 9, false);
#line 26 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
                               Write(user.name);

#line default
#line hidden
            EndContext();
            BeginContext(613, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(642, 25, false);
#line 27 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
                Write(user.sex == 0 ? "男" : "女");

#line default
#line hidden
            EndContext();
            BeginContext(668, 43, true);
            WriteLiteral("</td>\r\n                <td class=\"td-text\">");
            EndContext();
            BeginContext(712, 8, false);
#line 28 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
                               Write(user.age);

#line default
#line hidden
            EndContext();
            BeginContext(720, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(748, 10, false);
#line 29 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
               Write(user.level);

#line default
#line hidden
            EndContext();
            BeginContext(758, 87, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <button class=\"btn btn-default btn-sm\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 845, "\"", 869, 3);
            WriteAttributeValue("", 855, "edit(", 855, 5, true);
#line 31 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
WriteAttributeValue("", 860, user.id, 860, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 868, ")", 868, 1, true);
            EndWriteAttribute();
            BeginContext(870, 127, true);
            WriteLiteral(">查看</button>\r\n                    <button class=\"btn btn-danger btn-sm\">删除</button>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 35 "F:\dacheng\workspace\store\store\store\Views\User\List.cshtml"
        }

#line default
#line hidden
            BeginContext(1008, 43, true);
            WriteLiteral("    </table>\r\n\r\n    <!--引入分页Layout-->\r\n    ");
            EndContext();
            BeginContext(1051, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d117499ddf544a3f99e7b49c4d0f07cf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1098, 462, true);
            WriteLiteral(@"
</div>



<script>
    function edit(id) {
        location.href = ""../store/edit?goodsId="" + id;
    }

    function del(id) {
        $.ajax({
            url: 'delGoods',
            data: {
                goodsId: id
            },
            method: 'post',
            success: function (json) {
                alert(json);
                setTimeout(window.location.reload(), 2000);
            }
        });
    }


</script>");
            EndContext();
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
