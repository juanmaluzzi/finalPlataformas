#pragma checksum "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\My\Abm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f16a571f81eb9f4fbdddadfc4d415c7aaa99a572"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_My_Abm), @"mvc.1.0.view", @"/Views/My/Abm.cshtml")]
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
#line 1 "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\_ViewImports.cshtml"
using plataformasGrupo5TPFinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\_ViewImports.cshtml"
using plataformasGrupo5TPFinal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\My\Abm.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f16a571f81eb9f4fbdddadfc4d415c7aaa99a572", @"/Views/My/Abm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed48818e2c6bc955ef2da6dded663ec24e9f3a6c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_My_Abm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\My\Abm.cshtml"
  
    Layout = "LayoutMain";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<center>
    <div class=""card py-4 px-2"" style=""width: 300px"">
        <div class=""row"">
            <div class=""col-md-12"">
                <section>
                    <h4>
                        Hola
                        <span class=""text-info"">
                            ");
#nullable restore
#line 14 "C:\Users\franco.mastrantonio\Documents\Proyectos VS\finalPlataformas2207V2\plataformasGrupo5TPFinal\Views\My\Abm.cshtml"
                        Write(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </span>
                    </h4>
                    <hr />
                    <a href=""/Usuarios""><button class=""btn btn-dark btn-abm-list"">Usuarios</button></a>
                    <br />
                    <a href=""/Reservas""><button class=""btn btn-dark btn-abm-list"">Reservas</button></a>
                    <br />
                    <a href=""/Alojamientos""><button class=""btn btn-dark btn-abm-list"">Alojamientos</button></a>

                </section>
            </div>
        </div>
    </div>
</center>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
