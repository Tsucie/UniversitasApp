#pragma checksum "D:\UniversitasApp\UniversitasApp\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1cfad6a73c7b1038be6da8348061ba4bddc1365"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1cfad6a73c7b1038be6da8348061ba4bddc1365", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/Role.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\UniversitasApp\UniversitasApp\Views\Role\Index.cshtml"
  
    ViewBag.Title = "Roles";
    ViewBag.Logo = "Roles";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""PreviledgeModal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title""><b>Role Previledge</b></h4>
            </div>
            <div class=""modal-body"">
                <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                    <div class=""row"">
                        <div class=""card-table table-responsive"">
                            <table id=""tblRP"" class=""my-table"">
                                <thead>
                                    <tr>
                                        <th class=""status-user col-sm-1""><b>#</b></th>
                                        <th>Previledge</th>
                                       ");
            WriteLiteral(@" <th class=""col-md-1"">View</th>
                                        <th class=""col-md-1"">Add</th>
                                        <th class=""col-md-1"">Edit</th>
                                        <th class=""col-md-1"">Delete</th>
                                        <th class=""col-md-1""><b>Action</b></th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div hidden class=""modal-footer"" id=""mod-footer"">
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Batal</button>
                <button type=""button"" class=""btn btn-success"" id=""btn-simpan-role"">Simpan</button>
            </div>
        </div>
    </div>
</div>
<!-- Contet Header -->
<section class=""content-header"">
    <h1 class=""card-text"">
    Roles
  ");
            WriteLiteral("  </h1>\r\n    <ol class=\"breadcrumb\">\r\n        <li><a");
            BeginWriteAttribute("href", " href=\"", 2213, "\"", 2247, 1);
#nullable restore
#line 49 "D:\UniversitasApp\UniversitasApp\Views\Role\Index.cshtml"
WriteAttributeValue("", 2220, Url.Action("Index","Home"), 2220, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">Roles</li>
    </ol>
</section>
<!-- Main Content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box card-custom"">
                <div class=""box-header"">
                    <h2 class=""box-title""><b>Role List</b></h2>
                </div>
                <div class=""box-body"">
                    <div class=""dataTables_wrapper form-inline dt-bootstrap"" id=""example1_wrapper"">
                        <div id=""tbl-loading"" hidden></div>
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <table id=""tblRole"" class=""table table-bordered table-striped table-hover table-responsive"">
                                    <thead class=""bg-me"">
                                        <tr>
                                            <th class=""col-md-1"">No.<i class=""pull-right glyphicon glyphi");
            WriteLiteral(@"con-sort-by-attributes""></i></th>
                                            <th>Username<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Role Type<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
                                            <th>Role Name<i class=""pull-right glyphicon glyphicon-sort-by-attributes""></i></th>
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1cfad6a73c7b1038be6da8348061ba4bddc13658634", async() => {
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
