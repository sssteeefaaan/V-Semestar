#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13787ee9832617d7f98f494de856905b713fea2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Klubovi), @"mvc.1.0.razor-page", @"/Pages/Klubovi.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13787ee9832617d7f98f494de856905b713fea2d", @"/Pages/Klubovi.cshtml")]
    public class Pages_Klubovi : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
  
    ViewData["Title"] = "Klubovi";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"Styles/Stil.css\">\r\n");
            }
            );
            WriteLiteral("<h1>Lista video klubova naše baze podataka</h1>\r\n<table>\r\n    <tr>\r\n        <th>Naziv</th>\r\n        <th>Lista polica</th>\r\n        <th>Izmeni</th>\r\n        <th>Obriši</th>\r\n    </tr>\r\n");
#nullable restore
#line 19 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
     foreach (var item in Model.Klubovi)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
           Write(item.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 485, "\"", 516, 2);
            WriteAttributeValue("", 492, "./ViewPolice?id=", 492, 16, true);
#nullable restore
#line 23 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
WriteAttributeValue("", 508, item.ID, 508, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lista polica</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 559, "\"", 595, 2);
            WriteAttributeValue("", 566, "./UpdateVideoKlub?id=", 566, 21, true);
#nullable restore
#line 24 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
WriteAttributeValue("", 587, item.ID, 587, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Izmeni video klub</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 643, "\"", 679, 2);
            WriteAttributeValue("", 650, "./DeleteVideoKlub?id=", 650, 21, true);
#nullable restore
#line 25 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
WriteAttributeValue("", 671, item.ID, 671, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Obriši video klub</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 27 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\Klubovi.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<a class=\"novi\" href=\"./CreateVideoKlub\">Kreiraj novi video klub</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KluboviModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KluboviModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KluboviModel>)PageContext?.ViewData;
        public KluboviModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591