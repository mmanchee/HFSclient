<<<<<<< HEAD
#pragma checksum "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6f14760fdc24053b1e35cfa9381c02ec014fb28"
=======
#pragma checksum "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6f14760fdc24053b1e35cfa9381c02ec014fb28"
>>>>>>> mm/jnBranch
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
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
<<<<<<< HEAD
#line 4 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 4 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
using HFSclient.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6f14760fdc24053b1e35cfa9381c02ec014fb28", @"/Views/Account/Register.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegisterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
<<<<<<< HEAD
#line 1 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 1 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
  
  Layout = "_Layout";

#line default
#line hidden
            BeginContext(85, 40, true);
            WriteLiteral("\r\n<h2>Register a new user</h2>\r\n<hr />\r\n");
            EndContext();
<<<<<<< HEAD
#line 9 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 9 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
 using (Html.BeginForm("Register", "Account", FormMethod.Post))
{
  

#line default
#line hidden
            BeginContext(196, 22, false);
<<<<<<< HEAD
#line 11 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 11 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.Label("Username"));

#line default
#line hidden
            EndContext();
            BeginContext(223, 37, false);
<<<<<<< HEAD
#line 12 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 12 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.TextBoxFor(user=> user.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(269, 19, false);
<<<<<<< HEAD
#line 14 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 14 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.Label("Email"));

#line default
#line hidden
            EndContext();
            BeginContext(293, 34, false);
<<<<<<< HEAD
#line 15 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 15 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.TextBoxFor(user=> user.Email));

#line default
#line hidden
            EndContext();
            BeginContext(334, 22, false);
<<<<<<< HEAD
#line 17 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 17 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.Label("Password"));

#line default
#line hidden
            EndContext();
            BeginContext(361, 38, false);
<<<<<<< HEAD
#line 18 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 18 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.PasswordFor(user=> user.Password));

#line default
#line hidden
            EndContext();
            BeginContext(406, 30, false);
<<<<<<< HEAD
#line 20 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 20 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.Label("Confirm Password"));

#line default
#line hidden
            EndContext();
            BeginContext(441, 45, false);
<<<<<<< HEAD
#line 21 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 21 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
Write(Html.PasswordFor(user=> user.ConfirmPassword));

#line default
#line hidden
            EndContext();
            BeginContext(490, 44, true);
            WriteLiteral("  <input type=\"submit\" value=\"Register\" />\r\n");
            EndContext();
<<<<<<< HEAD
#line 24 "C:\Users\Danie\OneDrive\Desktop\HFSclient.Solutions\HFSClient\Views\Account\Register.cshtml"
=======
#line 24 "C:\Users\bnilles\Desktop\TeamWeekC#\HFSclient\HFSclient\Views\Account\Register.cshtml"
>>>>>>> mm/jnBranch
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591