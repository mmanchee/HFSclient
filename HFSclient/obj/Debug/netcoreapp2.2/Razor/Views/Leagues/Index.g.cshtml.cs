#pragma checksum "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df1910da624e486cb7913c7a6d2aeda74ae47e99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leagues_Index), @"mvc.1.0.view", @"/Views/Leagues/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Leagues/Index.cshtml", typeof(AspNetCore.Views_Leagues_Index))]
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
#line 4 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
using HFSclient.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df1910da624e486cb7913c7a6d2aeda74ae47e99", @"/Views/Leagues/Index.cshtml")]
    public class Views_Leagues_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
  
  Layout = "_Layout";

#line default
#line hidden
            BeginContext(56, 30, true);
            WriteLiteral("\r\n<h3>Current Leagues</h3>\r\n\r\n");
            EndContext();
#line 8 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
 if (@Model.Count == 0)
{

#line default
#line hidden
            BeginContext(114, 45, true);
            WriteLiteral("  <p>There are no Leauges in this list.</p>\r\n");
            EndContext();
#line 11 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
}

#line default
#line hidden
#line 12 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
 foreach (League league in Model)
{

#line default
#line hidden
            BeginContext(200, 6, true);
            WriteLiteral("  <li>");
            EndContext();
            BeginContext(207, 80, false);
#line 14 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
 Write(Html.ActionLink($"{league.LeagueName}", "Details", new { id = league.LeagueId }));

#line default
#line hidden
            EndContext();
            BeginContext(287, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 15 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
}

#line default
#line hidden
            BeginContext(297, 11, true);
            WriteLiteral("<br>\r\n\r\n<p>");
            EndContext();
            BeginContext(309, 94, false);
#line 18 "C:\users\Jeffrey\documents\epicodus\csharp\hfsclient.solution\hfsclient\Views\Leagues\Index.cshtml"
Write(Html.ActionLink("Add New League", "Create", null, null, new {@class="btn btn-success btn-sm"}));

#line default
#line hidden
            EndContext();
            BeginContext(403, 16, true);
            WriteLiteral("</p>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(490, 2, true);
            WriteLiteral("\r\n");
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
