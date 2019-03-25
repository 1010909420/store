#pragma checksum "F:\dacheng\workspace\store\store\store\Views\User\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e34468e09478585d946185eabcc938b0ea32a1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Edit), @"mvc.1.0.view", @"/Views/User/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Edit.cshtml", typeof(AspNetCore.Views_User_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e34468e09478585d946185eabcc938b0ea32a1c", @"/Views/User/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566700498a609f6e2f7139cc0b245fed22787aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 22, true);
            WriteLiteral("\r\n<div id=\"app\">\r\n    ");
            EndContext();
            BeginContext(22, 858, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a46771805ac4a20baada086844c7086", async() => {
                BeginContext(28, 845, true);
                WriteLiteral(@"
        <div class=""form-group"">
            <label>用户账号</label>
            <input type=""text"" class=""form-control"" id=""name"" placeholder=""商品名称"" v-model=""goods.name"">
        </div>
        <div class=""form-group"">
            <label>姓名</label>
            <input type=""text"" class=""form-control"" id=""presentation"" placeholder=""商品介绍"" v-model=""goods.presentation"">
        </div>
        <div class=""form-group"">
            <label>单价</label>
            <input type=""text"" class=""form-control"" id=""price"" placeholder=""单价"" v-model=""goods.price"">
        </div>
        <div class=""form-group"">
            <label>库存</label>
            <input type=""text"" class=""form-control"" id=""inventory"" placeholder=""库存"" v-model=""goods.inventory"">
        </div>
        <a class=""btn btn-default btn-block"" v-on:click=""submit"">确认</a>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(880, 2888, true);
            WriteLiteral(@"
</div>

<script>
    var app = new Vue({
        el: '#app',
        data: {
            user: {
                name: '',
                presentation: '',
                price: 0,
                inventory: 0,
            },
            imgNum: 1,
        },
        methods: {
            submit: function () {
                if (app.goods.name == null) {
                    toast(""请输入商品名称"");
                    return;
                }


                $.ajax({
                    url: 'addGoods',
                    data: app.goods,
                    method: 'post',
                    success: function (json) {
                        alert(json);
                    }
                });

            },

            uploadImg: function () {
                var file = document.getElementById('exampleInputFile_' + app.imgNum).files[0];
                //var fileM = document.querySelector(""#inputId"");
                //var fileObj = fileM.files[0];
              ");
            WriteLiteral(@"  if (file == null) {
                    toast('请选择上传的文件');
                    return;
                }

                var fd = new FormData();
                fd.append(""file"", file);

                $.ajax({
                    url: 'FileSave',
                    data: fd,
                    method: 'post',
                    processData: false,
                    contentType: false,
                    success: function (json) {
                        //toast(json);
                        app.goods[""pictureUrl"" + app.imgNum] = json;
                        if (app.imgNum < 6)
                            app.imgNum++;
                    }
                });
            },

            getFileId: function (count) {
                return ""exampleInputFile_"" + count;
            },

            delImgUrl: function (count) {
                //toast(count + 1);

                for (var i = count; i < app.imgNum; i++) {
                    var i2 = i + 1;
          ");
            WriteLiteral(@"          app.goods[""pictureUrl"" + i] = app.goods[""pictureUrl"" + i2];
                }

                app.imgNum--;
            }
        },
        mounted: function(){
            $(function () {
                var goodsId = $_Request[""goodsId""];
                $.ajax({
                    url: 'GetGoodsById',
                    data: {
                        goodsId: goodsId
                    },
                    success: function (json) {
                        app.goods = json;
                        for (var i = 1; i < 6; i++) {
                            if (app.goods[""pictureUrl"" + i] != null) {
                                app.imgNum++;
                            }
                        }
                    }
                });
            });
        }
    });

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
