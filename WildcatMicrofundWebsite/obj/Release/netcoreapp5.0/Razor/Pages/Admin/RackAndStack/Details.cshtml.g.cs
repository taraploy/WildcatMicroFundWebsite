#pragma checksum "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e595bb42d348c9218cb7e17e6cb7f43c034af89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WMF.Pages.Admin.RackAndStack.Pages_Admin_RackAndStack_Details), @"mvc.1.0.razor-page", @"/Pages/Admin/RackAndStack/Details.cshtml")]
namespace WMF.Pages.Admin.RackAndStack
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
#line 1 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\_ViewImports.cshtml"
using WMF;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\_ViewImports.cshtml"
using WMF.Areas;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e595bb42d348c9218cb7e17e6cb7f43c034af89", @"/Pages/Admin/RackAndStack/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ba0514dcf28a2eef65bc470a18fadfbc7722030", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_RackAndStack_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h2>Pitch Event on ");
#nullable restore
#line 6 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
              Write(Model.PitchEventsObj.PitchDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\n<div class=\"container center\">\n");
#nullable restore
#line 8 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
 foreach (var app in Model.ListOfApplications)
{
    var total = 0.0;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3 style=\"color:blue; border-bottom:solid;\">");
#nullable restore
#line 11 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
                                            Write(app.BusinessName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n");
#nullable restore
#line 12 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
     foreach (var quest in Model.ScoringQuestions)
    {
        var tot = 0.0;
        var cnt = 0;
        var avg = 0.0;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h5 style=\"color:rebeccapurple\">");
#nullable restore
#line 17 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
                                   Write(quest.ScoreQuestions);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n");
#nullable restore
#line 18 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
        var cards = Model.judgeAndScores.Where(u => u.applicationId == app.Id);
        cards = cards.Where(u => u.questionId == quest.ScoringQuestionId);
        foreach (var card in cards)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\n                <div class=\"col-6\">");
#nullable restore
#line 23 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
                              Write(card.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                <div class=\"col-6\">");
#nullable restore
#line 24 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
                              Write(card.score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n            </div> \n");
#nullable restore
#line 27 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
            cnt = cnt + 1;
            tot = tot + card.score;
            total = total + card.score;
        }
        avg = tot / cnt;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h6>Average:  ");
#nullable restore
#line 32 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
                 Write(avg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n");
#nullable restore
#line 33 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>TOTAL: ");
#nullable restore
#line 34 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
          Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n");
#nullable restore
#line 35 "O:\WeberStateUniversity\Catalyst Lab\Our Repo\WMF\WildcatMicrofundWebsite\WildcatMicrofundWebsite\Pages\Admin\RackAndStack\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WMF.Pages.Admin.RackAndStack.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WMF.Pages.Admin.RackAndStack.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WMF.Pages.Admin.RackAndStack.DetailsModel>)PageContext?.ViewData;
        public WMF.Pages.Admin.RackAndStack.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
