#pragma checksum "D:\UniversitasApp\UniversitasApp\Views\MataKuliah\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fb0e014623b8fcbccdf80e63fd9755f46de9008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MataKuliah_Index), @"mvc.1.0.view", @"/Views/MataKuliah/Index.cshtml")]
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
#line 1 "D:\UniversitasApp\UniversitasApp\Views\_ViewImports.cshtml"
using UniversitasApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\UniversitasApp\UniversitasApp\Views\_ViewImports.cshtml"
using UniversitasApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fb0e014623b8fcbccdf80e63fd9755f46de9008", @"/Views/MataKuliah/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_MataKuliah_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/MataKuliah.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\UniversitasApp\UniversitasApp\Views\MataKuliah\Index.cshtml"
  
    ViewBag.Title = "Mata Kuliah";
    ViewBag.Logo = "Mata Kuliah";
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fb0e014623b8fcbccdf80e63fd9755f46de90085135", async() => {
                WriteLiteral(@"
            <div class=""box-body"">
                <div class=""form-group"">
                    <label for=""prodi"" class=""col-sm-2 control-label"">Program Studi</label>
                    <div class=""col-sm-5"">
                        <select class=""form-control form-inputs"" name=""prodi"" id=""select-prodi""></select>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""semester"" class=""col-sm-2 control-label"">Semester</label>
                    <div class=""col-sm-5"">
                        <select class=""form-control form-inputs"" name=""semester"" id=""select-semester""></select>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""mk_code"" class=""col-sm-2 control-label"">Kode</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""mk_code"" placeholder=""Kode Mata Kuliah"" id=""mk_code");
                WriteLiteral(@""">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""mk_name"" class=""col-sm-2 control-label"">Nama</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""mk_name"" placeholder=""Nama Mata Kuliah"" id=""mk_name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""mk_desc"" class=""col-sm-2 control-label"">Deskripsi</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""mk_desc"" placeholder=""Deskripsi Mata Kuliah"" id=""mk_desc"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""mk_sks"" class=""col-sm-2 control-label"">Jumlah SKS</label>
                    <div class=""col-sm-10"">
                        <input type=""tel"" class=""form-co");
                WriteLiteral(@"ntrol form-inputs"" name=""mk_sks"" placeholder=""Jumlah Satuan Kredit Semester Mata Kuliah"" id=""mk_sks"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""mk_mutu"" class=""col-sm-2 control-label"">Syarat Mutu</label>
                    <div class=""col-sm-10"">
                        <input type=""tel"" class=""form-control form-inputs"" name=""mk_mutu"" placeholder=""Syarat Mutu Mata Kuliah"" id=""mk_mutu"">
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
        <button type=""button"" class=""btn btn-success"" id=""btn-add-matkul"">Tambah</button>
        <button type=""button"" class=""btn btn-success"" id=""btn-edit-matkul"">Edit</button>
      </div>
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
<!-- Contet Header -->
<section class=""content-header"">
    <h1 class=""card-text"">
    Mata Kuliah
    </h1>
    <ol class=""breadcrumb"">
        <li><a");
            BeginWriteAttribute("href", " href=\"", 3797, "\"", 3831, 1);
#nullable restore
#line 79 "D:\UniversitasApp\UniversitasApp\Views\MataKuliah\Index.cshtml"
WriteAttributeValue("", 3804, Url.Action("Index","Home"), 3804, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"" id=""active-link""></li>
    </ol>
</section>
<!-- Mata Kuliah Table Content -->
<section class=""content"" id=""category-table"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box card-custom"">
                <div class=""box-header"">
                    <h2 class=""box-title""><b>Mata Kuliah</b></h2>
                </div>
                <div class=""box-body"">
                    <div>
                        <label>
                            <a class=""btn btn-sm btn-success card-btn"" data-toggle=""modal"" data-target=""#AddEditModal"" id=""Add-btn""><strong>Add Mata Kuliah</strong></a>
                        </label>
                    </div>
                    <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                        <div id=""tbl-loading-1""");
            BeginWriteAttribute("class", " class=\"", 4749, "\"", 4757, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
                        <div class=""row"">
                            <div class=""col-sm-12 table-responsive"">
                                <table id=""tblStaff"" class=""table table-bordered table-striped table-hover"">
                                    <thead class=""bg-me"">
                                        <tr>
                                            <th>Semester<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Kode<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Mata Kuliah<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>SKS<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Mutu<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Action</t");
            WriteLiteral(@"h>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fb0e014623b8fcbccdf80e63fd9755f46de900812873", async() => {
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
