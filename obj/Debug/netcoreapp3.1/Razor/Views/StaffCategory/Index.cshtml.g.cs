#pragma checksum "D:\App\UniversitasApp\Views\StaffCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2852e2175a33c4716027d22cced5583d64b39cc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StaffCategory_Index), @"mvc.1.0.view", @"/Views/StaffCategory/Index.cshtml")]
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
#line 1 "D:\App\UniversitasApp\Views\_ViewImports.cshtml"
using UniversitasApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\App\UniversitasApp\Views\_ViewImports.cshtml"
using UniversitasApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2852e2175a33c4716027d22cced5583d64b39cc3", @"/Views/StaffCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_StaffCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/StaffCategory.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/Staff.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\App\UniversitasApp\Views\StaffCategory\Index.cshtml"
  
    ViewBag.Title = "Staff";
    ViewBag.Logo = "Staff";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- .modal -->
<div class=""modal fade"" id=""AddEditModal"" tabindex=""-1"" role=""dialog"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
        <h4 class=""modal-title""></h4>
      </div>
      <div class=""modal-body"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2852e2175a33c4716027d22cced5583d64b39cc35456", async() => {
                WriteLiteral(@"
            <div class=""box-body"">
                <div class=""form-group"">
                    <label for=""sc_name"" class=""col-sm-2 control-label"">Kategori</label>
                    <div class=""col-sm-4"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Nama Kategori"" id=""sc_name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""sc_desc"" class=""col-sm-2 control-label"">Deskripsi</label>
                    <div class=""col-sm-8"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Deskripsi Kategori"" id=""sc_desc"">
                    </div>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Kembali</button>
        <button type=""button"" class=""btn btn-success"" id=""btn-add-category"">Tambah</button>
        <button type=""button"" class=""btn btn-success"" id=""btn-edit-category"">Edit</button>
      </div>
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
<!-- Contet Header -->
<section class=""content-header"">
    <h1>
    Staff
    </h1>
    <ol class=""breadcrumb"">
        <li><a");
            BeginWriteAttribute("href", " href=\"", 1925, "\"", 1959, 1);
#nullable restore
#line 49 "D:\App\UniversitasApp\Views\StaffCategory\Index.cshtml"
WriteAttributeValue("", 1932, Url.Action("Index","Home"), 1932, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">Staff</li>
    </ol>
</section>
<!-- Main Content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box card-custom"">
                <div class=""box-header"">
                    <h2 class=""box-title""><b>Kategori Staff</b></h2>
                </div>
                <div class=""box-body"">
                    <div>
                        <label>
                            <a class=""btn btn-sm btn-success"" data-toggle=""modal"" data-target=""#AddEditModal"" id=""Add-btn""><strong>Add Staff Kategori</strong></a>
                        </label>
                    </div>
                    <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                        <div id=""spinner-1""></div>
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <table id=""tblStaff"" c");
            WriteLiteral(@"lass=""table table-bordered table-striped table-hover"">
                                    <thead class=""bg-me"">
                                        <tr>
                                            <th>Nomor<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Kategori<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Deskripsi<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class=""content"">
    <div class=""row"">
  ");
            WriteLiteral(@"      <div class=""col-xs-12"">
            <div class=""box card-custom"">
                <div class=""box-header"">
                    <h2 class=""box-title""><b>Staff List</b></h2>
                </div>
                <div class=""box-body"">
                    <div>
                        <label>
                            <a");
            BeginWriteAttribute("href", " href=\"", 4344, "\"", 4390, 1);
#nullable restore
#line 100 "D:\App\UniversitasApp\Views\StaffCategory\Index.cshtml"
WriteAttributeValue("", 4351, Url.Action("AddStaff","StaffCategory"), 4351, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-success""><strong>Add Staff</strong></a>
                        </label>
                    </div>
                    <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                        <div id=""spinner-2""></div>
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <table id=""tblStaff-detail"" class=""table table-bordered table-striped table-hover"">
                                    <thead class=""bg-me"">
                                        <tr>
                                            <th>Nama<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Kategori<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>NIK<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Emai");
            WriteLiteral(@"l<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>No.Telpon<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Status Keaktifan<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2852e2175a33c4716027d22cced5583d64b39cc313352", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2852e2175a33c4716027d22cced5583d64b39cc314539", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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