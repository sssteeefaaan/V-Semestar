#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1756862194584924d39d249c1b853e4bb3bb28f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_UpdatePolica), @"mvc.1.0.razor-page", @"/Pages/UpdatePolica.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1756862194584924d39d249c1b853e4bb3bb28f", @"/Pages/UpdatePolica.cshtml")]
    public class Pages_UpdatePolica : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
  
    Layout = "_Layout";
    ViewData["Tittle"] = "Izmeni policu";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Izmena police ");
#nullable restore
#line 8 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
             Write(Model.Polica.Oznaka);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<form method=\"POST\">\r\n    ");
#nullable restore
#line 10 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <p>??anr: <input type=\"text\" name=\"Polica.Oznaka\"");
            BeginWriteAttribute("value", " value=\"", 278, "\"", 306, 1);
#nullable restore
#line 11 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
WriteAttributeValue("", 286, Model.Polica.Oznaka, 286, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\r\n    <p>Boja: <input type=\"text\" name=\"Polica.Boja\"");
            BeginWriteAttribute("value", " value=\"", 364, "\"", 390, 1);
#nullable restore
#line 12 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
WriteAttributeValue("", 372, Model.Polica.Boja, 372, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\r\n    <p>Current: <input type=\"number\" name=\"Polica.Curr\"");
            BeginWriteAttribute("value", " value=\"", 453, "\"", 479, 1);
#nullable restore
#line 13 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
WriteAttributeValue("", 461, Model.Polica.Curr, 461, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></p>\r\n    <p>Max: <input type=\"number\" name=\"Polica.Max\"");
            BeginWriteAttribute("value", " value=\"", 537, "\"", 562, 1);
#nullable restore
#line 14 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\UpdatePolica.cshtml"
WriteAttributeValue("", 545, Model.Polica.Max, 545, 17, false);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UpdatePolicaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UpdatePolicaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UpdatePolicaModel>)PageContext?.ViewData;
        public UpdatePolicaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
