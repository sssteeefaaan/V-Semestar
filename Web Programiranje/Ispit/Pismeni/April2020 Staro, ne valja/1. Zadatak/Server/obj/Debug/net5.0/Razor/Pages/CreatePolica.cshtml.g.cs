#pragma checksum "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\CreatePolica.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80f274d0f88aa1fd95505eba7f5510e38a3610f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_CreatePolica), @"mvc.1.0.razor-page", @"/Pages/CreatePolica.cshtml")]
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
#line 2 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\CreatePolica.cshtml"
using Server.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80f274d0f88aa1fd95505eba7f5510e38a3610f3", @"/Pages/CreatePolica.cshtml")]
    public class Pages_CreatePolica : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\CreatePolica.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Kreiraj novu policu";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Unesite informacije o novoj polici za video klub\"");
#nullable restore
#line 8 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\CreatePolica.cshtml"
                                                Write(Model.Polica.VideoKlub.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h2>\r\n<form method=\"POST\">\r\n    ");
#nullable restore
#line 10 "C:\Users\stefa\Documents\Faks\III godina\V semestar\Web Programiranje\Ispit\April2020\1. Zadatak\Server\Pages\CreatePolica.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <p><input type=""text"" name=""Polica.Oznaka"" placeholder=""??anr""></p>
    <p><input type=""text"" name=""Polica.Boja"" placeholder=""Boja""></p>
    <p><input type=""number"" name=""Polica.Curr"" placeholder=""Trenutno""></p>
    <p><input type=""number"" name=""Polica.Max"" placeholder=""Max""></p>
    <p><input type=""submit"" value=""Dodaj novu policu""></p>
</form>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreatePolicaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreatePolicaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreatePolicaModel>)PageContext?.ViewData;
        public CreatePolicaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
