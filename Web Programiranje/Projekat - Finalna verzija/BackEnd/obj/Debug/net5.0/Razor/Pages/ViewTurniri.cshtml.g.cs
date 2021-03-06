#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5be4aa3321346db43d89dbd1161547f14edb0901"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_ViewTurniri), @"mvc.1.0.razor-page", @"/Pages/ViewTurniri.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5be4aa3321346db43d89dbd1161547f14edb0901", @"/Pages/ViewTurniri.cshtml")]
    public class Pages_ViewTurniri : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
  
    Layout = "_Layout";
    ViewData["Tittle"] = "Turniri";

#line default
#line hidden
#nullable disable
            DefineSection("Style", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"Styles/Stil.css\">\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script src=\"Scripts/ScriptViewTurniri.js\"></script>\n");
            }
            );
            WriteLiteral(@"
<h1>Lista svih turnira u bazi podataka</h1>
<table>
    <tr>
        <th>Naziv</th>
        <th>Broj Disciplina</th>
        <th>Maksimalni Broj Disciplina</th>
        <th>Trenutni Broj U??esnika</th>
        <th>Discipline</th>
        <th>Izmeni</th>
        <th>Obri??i</th>
    </tr>
");
#nullable restore
#line 26 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
     for(int i = 0; i < Model.Turniri.Count; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 29 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
           Write(Model.Turniri[i].Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 30 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
           Write(Model.TrenutniBrojDisciplina[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 31 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
           Write(Model.Turniri[i].MaxDisciplina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 32 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
           Write(Model.TrenutniBrojUcesnika[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 840, "\"", 900, 2);
            WriteAttributeValue("", 847, "./ViewDisciplineTurnira?turnirID=", 847, 33, true);
#nullable restore
#line 33 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
WriteAttributeValue("", 880, Model.Turniri[i].ID, 880, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lista disciplina</a></td>\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 946, "\"", 997, 2);
            WriteAttributeValue("", 953, "./UpdateTurnir?turnirID=", 953, 24, true);
#nullable restore
#line 34 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
WriteAttributeValue("", 977, Model.Turniri[i].ID, 977, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Izmenite turnir</a></td>\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 1042, "\"", 1093, 2);
            WriteAttributeValue("", 1049, "./DeleteTurnir?turnirID=", 1049, 24, true);
#nullable restore
#line 35 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
WriteAttributeValue("", 1073, Model.Turniri[i].ID, 1073, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Obri??ite turnir</a></td>\n        </tr>\n");
#nullable restore
#line 37 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\ViewTurniri.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewTurniriModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ViewTurniriModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ViewTurniriModel>)PageContext?.ViewData;
        public ViewTurniriModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
