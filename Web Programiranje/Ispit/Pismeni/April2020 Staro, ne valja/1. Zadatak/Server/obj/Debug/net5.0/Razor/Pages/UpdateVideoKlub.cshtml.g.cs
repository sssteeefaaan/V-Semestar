#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fb982880bd4603a0112e556ffc445b793170acb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_UpdateVideoKlub), @"mvc.1.0.razor-page", @"/Pages/UpdateVideoKlub.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fb982880bd4603a0112e556ffc445b793170acb", @"/Pages/UpdateVideoKlub.cshtml")]
    public class Pages_UpdateVideoKlub : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml"
  
    Layout = "_Layout";
    ViewData["Tittle"] = "Izmeni video klub";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Izmeni video klub \"");
#nullable restore
#line 8 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml"
                  Write(Model.VKlub.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h1>\r\n<form method=\"POST\">\r\n    ");
#nullable restore
#line 10 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <p><input type=\"text\" name=\"VKlub.Naziv\"");
            BeginWriteAttribute("value", " value=\"", 281, "\"", 307, 1);
#nullable restore
#line 11 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdateVideoKlub.cshtml"
WriteAttributeValue("", 289, Model.VKlub.Naziv, 289, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\r\n    <p><input type=\"submit\" value=\"Izmeni\"></p>\r\n</form>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UpdateVideoKlubModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UpdateVideoKlubModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UpdateVideoKlubModel>)PageContext?.ViewData;
        public UpdateVideoKlubModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591