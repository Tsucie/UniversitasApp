#pragma checksum "D:\UniversitasApp\UniversitasApp\Views\Site\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fc05edface3f0643219400064268ceb0c960b86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Site_Index), @"mvc.1.0.view", @"/Views/Site/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fc05edface3f0643219400064268ceb0c960b86", @"/Views/Site/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_Site_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Rektor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Wakil Rektor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Laki-laki", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Perempuan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/Site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\UniversitasApp\UniversitasApp\Views\Site\Index.cshtml"
  
    ViewBag.Title = "Rektor & Wakil Rektor";
    ViewBag.Logo = "Rektor & Wakil Rektor";
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b867023", async() => {
                WriteLiteral("\r\n            <div class=\"box-body\">\r\n                <div class=\"form-group\">\r\n                    <div class=\"col-sm-5\">\r\n                        <img id=\"profile-img\"");
                BeginWriteAttribute("src", " src=\"", 773, "\"", 779, 0);
                EndWriteAttribute();
                WriteLiteral(@" width=""100"" height=""100""/>
                        <div>
                            <label for=""u_file"" class=""control-label"">Photo Profile</label>
                            <input type=""file"" class=""form-control-file"" id=""u_file"" accept=""image/*"">
                        </div>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""u_username"" class=""col-sm-2 control-label"">Username</label>
                    <div class=""col-sm-5"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Username"" id=""u_username"">
                        <div hidden id=""username-alrt"" class=""alert alert-danger"" role=""alert"">
                            <span class=""glyphicon glyphicon-exclamation-sign"" aria-hidden=""true""></span>
                            <span class=""sr-only"">Error:</span>
                            Username tidak boleh kosong!
                        </div>
                    </div>
");
                WriteLiteral(@"                </div>
                <div hidden class=""form-group"" id=""pass-txtbox"">
                    <label for=""u_password"" class=""col-sm-2 control-label"">Password</label>
                    <div class=""col-sm-5"">
                        <input type=""password"" class=""form-control form-inputs"" placeholder=""Password"" id=""u_password"">
                        <div hidden id=""password-alrt"" class=""alert alert-danger"" role=""alert"">
                            <span class=""glyphicon glyphicon-exclamation-sign"" aria-hidden=""true""></span>
                            <span class=""sr-only"">Error:</span>
                            Password Tidak boleh kosong!
                        </div>
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_fullname"" class=""col-sm-2 control-label"">Nama Lengkap</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" place");
                WriteLiteral(@"holder=""Nama Lengkap"" id=""s_fullname"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_email"" class=""col-sm-2 control-label"">Email</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Email"" id=""s_email"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_contact"" class=""col-sm-2 control-label"">Kontak</label>
                    <div class=""col-sm-10"">
                        <input type=""tel"" class=""form-control form-inputs"" placeholder=""Nomor Telepon"" id=""s_contact"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""r_desc"" class=""col-sm-2 control-label"">Jabatan</label>
                    <div class=""col-sm-4"">
                        <select class=""form-control form-inputs"" id=""r_d");
                WriteLiteral("esc\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8610961", async() => {
                    WriteLiteral("Rektor");
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8612213", async() => {
                    WriteLiteral("Wakil rektor");
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
                    <label for=""s_nik"" class=""col-sm-2 control-label"">NIK</label>
                    <div class=""col-sm-10"">
                        <input type=""tel"" class=""form-control form-inputs"" placeholder=""Nomor Induk Kepegawaian"" id=""s_nik"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_address"" class=""col-sm-2 control-label"">Alamat</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Alamat Jalan, Perumahan, kelurahan, dan kecamatan"" id=""s_address"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_city"" class=""col-sm-2 control-label"">Kota</label>
                    <div class=""col-sm-10"">
                        <inpu");
                WriteLiteral(@"t type=""text"" class=""form-control form-inputs"" placeholder=""Kota tempat tinggal"" id=""s_city"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_province"" class=""col-sm-2 control-label"">Provinsi</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Provinsi tempat tinggal"" id=""s_province"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_birthplace"" class=""col-sm-2 control-label"">Tempat Lahir</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Kota Asal"" id=""s_birthplace"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_birthdate"" class=""col-sm-2 control-label"">Tanggal Lahir</label>
              ");
                WriteLiteral(@"      <div class=""col-sm-10"">
                        <input type=""date"" class=""form-control form-inputs"" placeholder=""Tanggal kelahiran"" id=""s_birthdate"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_gender"" class=""col-sm-2 control-label"">Jenis Kelamin</label>
                    <div class=""col-sm-4"">
                        <select class=""form-control form-inputs"" id=""s_gender"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8616169", async() => {
                    WriteLiteral("Laki-laki");
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8617424", async() => {
                    WriteLiteral("Perempuan");
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
                    <label for=""s_religion"" class=""col-sm-2 control-label"">Agama</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Agama"" id=""s_religion"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_state"" class=""col-sm-2 control-label"">Negara</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control form-inputs"" placeholder=""Warga Negara"" id=""s_state"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""s_stat"" class=""col-sm-2 control-label"">Status</label>
                    <div class=""col-sm-4"">
                        <select class=""form-control form-inputs"" id=""s_sta");
                WriteLiteral("t\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8619786", async() => {
                    WriteLiteral("Aktif");
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
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8621037", async() => {
                    WriteLiteral("Tidak Aktif");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
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
        <button type=""button"" class=""btn btn-success"" id=""btn-add-site"">Tambah</button>
        <button type=""button"" class=""btn btn-success"" id=""btn-edit-site"">Edit</button>
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
    Rektor &amp; Wakil Rektor
    </h1>
    <ol class=""breadcrumb"">
        <li><a");
            BeginWriteAttribute("href", " href=\"", 8563, "\"", 8597, 1);
#nullable restore
#line 161 "D:\UniversitasApp\UniversitasApp\Views\Site\Index.cshtml"
WriteAttributeValue("", 8570, Url.Action("Index","Home"), 8570, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">Rektor &amp; Wakil Rektor</li>
    </ol>
</section>
<!-- Main Content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box card-custom"">
                <div class=""box-header"">
                    <h2 class=""box-title""><b>Rektor &amp; Wakil Rektor List</b></h2>
                </div>
                <div class=""box-body"">
                    <div>
                        <label>
                            <a class=""btn btn-sm btn-success card-btn"" data-toggle=""modal"" data-target=""#AddEditModal"" id=""Add-btn""><strong>Add Site</strong></a>
                        </label>
                    </div>
                    <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                        <div id=""spinner""");
            BeginWriteAttribute("class", " class=\"", 9496, "\"", 9504, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div></div>
                        <div class=""row"">
                            <div class=""col-sm-12 table-responsive"">
                                <table id=""tblSite"" class=""table table-bordered table-striped table-hover"">
                                    <thead class=""bg-me"">
                                        <tr>
                                            <th>Photo</th>
                                            <th>Username<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Nama Lengkap<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Nik<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Jabatan<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Status<i class=""pull-right glyphicon glyphicon-sort-by-attribute");
            WriteLiteral(@"s""></i></th>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fc05edface3f0643219400064268ceb0c960b8627127", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
