#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\CreateTurnir.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "726510992dba4bad0e106ac0dcee26be73053cec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_CreateTurnir), @"mvc.1.0.razor-page", @"/Pages/CreateTurnir.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\CreateTurnir.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"726510992dba4bad0e106ac0dcee26be73053cec", @"/Pages/CreateTurnir.cshtml")]
    public class Pages_CreateTurnir : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\CreateTurnir.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Napravi novi turnir";

#line default
#line hidden
#nullable disable
            DefineSection("Style", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"Styles/FormStil.css\">\n");
            }
            );
            WriteLiteral("<div class=\"Container\">\n    <h1>Unesite naziv novog turnira:</h1>\n    <form method=\"POST\">\n        ");
#nullable restore
#line 14 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Projekat - Finalna verzija\BackEnd\Pages\CreateTurnir.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <p><input type=""text"" name=""Turnir.Naziv"" placeholder=""Naziv novog turnira""></p>
        <p><input type=""number"" name=""Turnir.MaxDisciplina"" placeholder=""Maksimalni broj disciplina""></p>
        <p><input type=""submit"" value=""Dodaj novi turnir""></p>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateTurnirModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreateTurnirModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreateTurnirModel>)PageContext?.ViewData;
        public CreateTurnirModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
