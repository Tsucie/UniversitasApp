#pragma checksum "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02cef724ba40791ecadbc07b852fbdb5520fce87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MainMenu), @"mvc.1.0.view", @"/Views/Shared/_MainMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02cef724ba40791ecadbc07b852fbdb5520fce87", @"/Views/Shared/_MainMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4773d9f18124e39f3c5870385561d91e5131fde7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MainMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<ul class=""sidebar-menu"" data-widget=""tree"">
    <li class=""header"">MAIN MENU</li>
    <li class=""treeview"">
        <a href=""#"">
            <i class=""fa fa-dashboard""></i> <span>Dashboard</span>
            <span class=""pull-right-container"">
                <i class=""fa fa-angle-left pull-right""></i>
            </span>
        </a>
        <ul class=""treeview-menu"">
            <li><a");
            BeginWriteAttribute("href", " href=\"", 401, "\"", 435, 1);
#nullable restore
#line 11 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 408, Url.Action("Index","Home"), 408, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-home\"></i> Home </a></li>\r\n            <li><a");
            BeginWriteAttribute("href", " href=\"", 498, "\"", 532, 1);
#nullable restore
#line 12 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 505, Url.Action("Index","User"), 505, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-users""></i> User Activity </a></li>
        </ul>
    </li>
    <li class=""treeview"">
        <a href=""#"">
            <i class=""fa fa-gears""></i> <span>Roles</span>
            <span class=""pull-right-container"">
                <i class=""fa fa-angle-left pull-right""></i>
            </span>
        </a>
        <ul class=""treeview-menu"">
            <li><a");
            BeginWriteAttribute("href", " href=\"", 921, "\"", 955, 1);
#nullable restore
#line 23 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 928, Url.Action("Index","Role"), 928, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-gear""></i> Role User </a></li>
        </ul>
    </li>
    <li class=""treeview"">
        <a href=""#"">
            <i class=""fa fa-users""></i> <span>User List</span>
            <span class=""pull-right-container"">
                <i class=""fa fa-angle-left pull-right""></i>
            </span>
        </a>
        <ul class=""treeview-menu"">
            <li><a");
            BeginWriteAttribute("href", " href=\"", 1343, "\"", 1379, 1);
#nullable restore
#line 34 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 1350, Url.Action("Index","Client"), 1350, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-user\"></i> Client </a></li>\r\n            <li><a");
            BeginWriteAttribute("href", " href=\"", 1444, "\"", 1478, 1);
#nullable restore
#line 35 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 1451, Url.Action("Index","Site"), 1451, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-user\"></i> Rektor & Wakil Rektor </a></li>\r\n            <li><a");
            BeginWriteAttribute("href", " href=\"", 1558, "\"", 1601, 1);
#nullable restore
#line 36 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 1565, Url.Action("Index","StaffCategory"), 1565, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-user\"></i> Staff </a></li>\r\n            <li><a");
            BeginWriteAttribute("href", " href=\"", 1665, "\"", 1704, 1);
#nullable restore
#line 37 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 1672, Url.Action("Index","Mahasiswa"), 1672, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa-user""></i> Mahasiswa </a></li>
        </ul>
    </li>
    <li class=""treeview"">
        <a href=""#"">
            <i class=""glyphicon glyphicon-education""></i> <span>Akademik</span>
            <span class=""pull-right-container"">
                <i class=""fa fa-angle-left pull-right""></i>
            </span>
        </a>
        <ul class=""treeview-menu"">
            <li><a");
            BeginWriteAttribute("href", " href=\"", 2109, "\"", 2147, 1);
#nullable restore
#line 48 "D:\UniversitasApp\UniversitasApp\Views\Shared\_MainMenu.cshtml"
WriteAttributeValue("", 2116, Url.Action("Index","Fakultas"), 2116, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-graduation-cap\"></i> Fakultas </a></li>\r\n            <li><a href=\"#\"><i class=\"fa fa-book\"></i> Mata Kuliah </a></li>\r\n            <li><a href=\"#\"><i class=\"glyphicon glyphicon-book\"></i> Nilai </a></li>\r\n        </ul>\r\n    </li>\r\n</ul>");
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
