#pragma checksum "D:\UniversitasApp\UniversitasApp\Views\Mahasiswa\UpdateMhs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b9f60f986fee3b17d36576bdee3981de14ea064"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mahasiswa_UpdateMhs), @"mvc.1.0.view", @"/Views/Mahasiswa/UpdateMhs.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b9f60f986fee3b17d36576bdee3981de14ea064", @"/Views/Mahasiswa/UpdateMhs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_Mahasiswa_UpdateMhs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Laki-laki", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Perempuan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form-edit_mhs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/Mahasiswa.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\UniversitasApp\UniversitasApp\Views\Mahasiswa\UpdateMhs.cshtml"
  
    ViewBag.Title = "Update Mahasiswa";
    ViewBag.Logo = "Mahasiswa";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Contet Header -->\r\n<section class=\"content-header\">\r\n    <h1>\r\n    Mahasiswa\r\n    </h1>\r\n    <ol class=\"breadcrumb\">\r\n        <li><a");
            BeginWriteAttribute("href", " href=\"", 265, "\"", 299, 1);
#nullable restore
#line 12 "D:\UniversitasApp\UniversitasApp\Views\Mahasiswa\UpdateMhs.cshtml"
WriteAttributeValue("", 272, Url.Action("Index","Home"), 272, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">User</li>
        <li class=""active"">Update Mahasiswa</li>
    </ol>
</section>
<!-- Main Content -->
<section class=""content container-fluid"">
    <!-- Horizontal Form -->
    <div class=""box box-info card-custom"">
        <div class=""box-header with-border"">
            <h3 class=""box-title"">Update Mahasiswa</h3>
        </div>
        <!-- /.box-header -->
        <!-- form start -->
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea0647371", async() => {
                WriteLiteral(@"
            <div class=""box-body"">
                <div class=""form-group"">
                    <label for=""edit_u_username"" class=""col-sm-2 control-label"">UserName</label>
                    <div class=""col-sm-4"">
                        <input type=""text"" class=""form-control form-inputs"" name=""UserName"" placeholder=""UserName"" id=""edit_u_username"">
                        <div hidden id=""username-alrt"" class=""alert alert-danger"" role=""alert"">
                            <span class=""glyphicon glyphicon-exclamation-sign"" aria-hidden=""true""></span>
                            <span class=""sr-only"">Error:</span>
                            Username tidak boleh kosong!
                        </div>
                    </div>
                </div>
");
                WriteLiteral("            </div>\r\n            <!-- /.box-body -->\r\n            <div class=\"box-header with-border\">\r\n                <h3 class=\"box-title\">Details</h3>\r\n            </div>\r\n            <div class=\"box-body\" id=\"form-section\">\r\n");
                WriteLiteral(@"                <div class=""form-group"">
                    <label for=""edit_mhs_fullname"" class=""col-sm-2 control-label"">Nama Lengkap</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_fullname"" placeholder=""Nama Lengkap"" id=""edit_mhs_fullname"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_nim"" class=""col-sm-2 control-label"">Nomor Induk Mahasiswa</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_nim"" placeholder=""NIM"" id=""edit_mhs_nim"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_kelas"" class=""col-sm-2 control-label"">Kelas</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control for");
                WriteLiteral(@"m-inputs"" name=""edit_mhs_kelas"" placeholder=""Kelas"" id=""edit_mhs_kelas"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_address"" class=""col-sm-2 control-label"">Alamat</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_address"" placeholder=""Alamat"" id=""edit_mhs_address"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_province"" class=""col-sm-2 control-label"">Provinsi</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_province"" placeholder=""Provinsi"" id=""edit_mhs_province"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_city"" class=""col-sm-2 control-label"">Kota</lab");
                WriteLiteral(@"el>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_city"" placeholder=""Kota"" id=""edit_mhs_city"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_birthplace"" class=""col-sm-2 control-label"">Tempat Lahir</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_birthplace"" placeholder=""Tempat Lahir"" id=""edit_mhs_birthplace"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_birthdate"" class=""col-sm-2 control-label"">Tanggal Lahir</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_birthdate"" placeholder=""Tanggal Lahir"" id=""edit_mhs_birthdate"">
                    </div>
      ");
                WriteLiteral(@"          </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_gender"" class=""col-sm-2 control-label"">Jenis Kelamin</label>
                    <div class=""col-sm-2"">
                        <select class=""form-control form-inputs"" id=""edit_mhs_gender"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea06412408", async() => {
                    WriteLiteral("Laki-laki");
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
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea06413663", async() => {
                    WriteLiteral("Perempuan");
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
                WriteLiteral(@"
                        </select>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_religion"" class=""col-sm-2 control-label"">Agama</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_religion"" placeholder=""Agama"" id=""edit_mhs_religion"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_state"" class=""col-sm-2 control-label"">Kewarganegaraan</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_state"" placeholder=""Kewarganegaraan"" id=""edit_mhs_state"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_email"" class=""col-sm-2 control-label"">Email</label>
                    <div");
                WriteLiteral(@" class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_email"" placeholder=""Email"" id=""edit_mhs_email"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_stat"" class=""col-sm-2 control-label"">Status Mahasiswa</label>
                    <div class=""col-sm-2"">
                        <select class=""form-control form-inputs"" id=""edit_mhs_stat"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea06416530", async() => {
                    WriteLiteral("Aktif");
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
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea06417781", async() => {
                    WriteLiteral("Tidak Aktif");
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
                WriteLiteral(@"
                        </select>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""edit_mhs_telp"" class=""col-sm-2 control-label"">Nomor Telpon</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" name=""edit_mhs_telp"" placeholder=""Nomor Telpon"" id=""edit_mhs_telp"">
                    </div>
                </div>
            </div>
            <div class=""box-footer card-custom"">
                <a class=""btn btn-default"" href=""../Mahasiswa"" role=""button"">Cancel</a>
                <a><button type=""button"" class=""btn btn-success pull-right"" id=""btn-edit-mhs"">Edit</button></a>
            </div>
            <!-- /.box-footer -->
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <!-- /form end -->\r\n    </div>\r\n    <!-- /.box -->\r\n</section>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b9f60f986fee3b17d36576bdee3981de14ea06421168", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
