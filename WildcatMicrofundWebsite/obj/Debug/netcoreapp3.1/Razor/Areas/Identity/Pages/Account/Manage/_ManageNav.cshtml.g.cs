#pragma checksum "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc1d92e579110e07e60329524f0ae652d13f5c5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage__ManageNav), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/Manage/_ManageNav.cshtml")]
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
#line 1 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\_ViewImports.cshtml"
using WMF.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\_ViewImports.cshtml"
using WMF.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using WMF.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using WMF.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using WMF.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc1d92e579110e07e60329524f0ae652d13f5c5d", @"/Areas/Identity/Pages/Account/Manage/_ManageNav.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f1755d00e1a046adc190b1f4b6430c52bc785d5", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a457f4d1c2e75eb2dca0d40eb292d2dd3bc6598", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e842a8f3a39c47ce29f6e09c79564793622afb", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage__ManageNav : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Areas\Identity\Pages\Account\Manage\_ManageNav.cshtml"
  
    var hasExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).Any();

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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