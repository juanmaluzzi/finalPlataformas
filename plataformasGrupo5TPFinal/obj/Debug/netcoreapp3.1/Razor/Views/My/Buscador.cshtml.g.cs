#pragma checksum "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0c115987703f0f2ee58e3c3aa212c41088c6454"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_My_Buscador), @"mvc.1.0.view", @"/Views/My/Buscador.cshtml")]
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
#line 1 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\_ViewImports.cshtml"
using plataformasGrupo5TPFinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\_ViewImports.cshtml"
using plataformasGrupo5TPFinal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0c115987703f0f2ee58e3c3aa212c41088c6454", @"/Views/My/Buscador.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed48818e2c6bc955ef2da6dded663ec24e9f3a6c", @"/Views/_ViewImports.cshtml")]
    public class Views_My_Buscador : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "My", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Buscador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reservas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
  
    Layout = "LayoutMain";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c64545701", async() => {
                WriteLiteral("\r\n    <p>\r\n        Nombre <input typepe=\"text\" name=\"searchString\" />\r\n        <input type=\"submit\" value=\"Filtrar\" />\r\n    </p>\r\n    <select class=\"form-select\" aria-label=\"Ciudad\" name=\"searchCiudad\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c64546193", async() => {
                    WriteLiteral("Elija una ciudad");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
         foreach (Hotel hotel in Model.Hotel)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c64547840", async() => {
#nullable restore
#line 16 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                     Write(hotel.ciudad);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
               WriteLiteral(hotel.ciudad);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
         foreach (Cabaña cabania in Model.Cabaña)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c645410270", async() => {
#nullable restore
#line 20 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                       Write(cabania.ciudad);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
               WriteLiteral(cabania.ciudad);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </select>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n");
#nullable restore
#line 32 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
             foreach (Hotel hotel in Model.Hotel)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mb-4\">\r\n                    <h5 class=\"card-header\"> ");
#nullable restore
#line 35 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                        Write(hotel.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    <img class=""card-img-top"" src=""https://fakeimg.pl/800x400/"" alt=""Imagen Alojamiento"">
                    <div class=""card-body"">

                        <h6 class=""card-subtitle mb-2 text-muted"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-geo-alt-fill"" viewBox=""0 0 16 16"">
                                <path d=""M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z"" />
                            </svg> ");
#nullable restore
#line 42 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                              Write(hotel.ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 42 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                              Write(hotel.barrio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n\r\n                        <div>\r\n                            <p class=\"float-left\"> ");
#nullable restore
#line 46 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                              Write(hotel.cantPersonas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" huéspedes</p>\r\n                            <p class=\"float-right\">TV ");
#nullable restore
#line 47 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                 Write(hotel.tv);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                        </div>\r\n                        <br />\r\n                        <div class=\"row my-auto align-content-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c645416950", async() => {
                WriteLiteral("Reservar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                                                                    WriteLiteral(hotel.codigo);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer text-muted\">\r\n                        <div>\r\n                            <p class=\"float-left\">\r\n                                ");
#nullable restore
#line 57 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                           Write(hotel.estrellas);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-star-fill .text-warning"" viewBox=""0 0 16 16"">
                                    <path d=""M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"" />
                                </svg>
                            </p>
                            <p class=""float-right .text-success""> $ ");
#nullable restore
#line 61 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                               Write(hotel.precioPorPersona);

#line default
#line hidden
#nullable disable
            WriteLiteral("  (Precio por Persona)</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 65 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
             foreach (Cabaña cabania in Model.Cabaña)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mb-4\">\r\n                    <h5 class=\"card-header\"> ");
#nullable restore
#line 69 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                        Write(cabania.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    <img class=""card-img-top"" src=""https://fakeimg.pl/800x400/"" alt=""Imagen Alojamiento"">
                    <div class=""card-body"">

                        <h6 class=""card-subtitle mb-2 text-muted"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-geo-alt-fill"" viewBox=""0 0 16 16"">
                                <path d=""M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z"" />
                            </svg> ");
#nullable restore
#line 76 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                              Write(cabania.ciudad);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , ");
#nullable restore
#line 76 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                Write(cabania.barrio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n\r\n                        <div>\r\n                            <p class=\"float-left\"> ");
#nullable restore
#line 80 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                              Write(cabania.cantPersonas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" huéspedes</p>\r\n                            <p class=\"float-right\">TV ");
#nullable restore
#line 81 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                 Write(cabania.tv);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                        </div>\r\n                        <br />\r\n                        <div class=\"row my-auto align-content-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c115987703f0f2ee58e3c3aa212c41088c645424089", async() => {
                WriteLiteral("Reservar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                                                                    WriteLiteral(cabania.codigo);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer text-muted\">\r\n                        <div>\r\n                            <p class=\"float-left\">\r\n                                ");
#nullable restore
#line 91 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                           Write(cabania.estrellas);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-star-fill .text-warning"" viewBox=""0 0 16 16"">
                                    <path d=""M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z"" />
                                </svg>
                            </p>
                            <p class=""float-right .text-success""> $ ");
#nullable restore
#line 95 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
                                                               Write(cabania.precioDia);

#line default
#line hidden
#nullable disable
            WriteLiteral("  (Precio por Dia)</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 99 "C:\Users\franco.mastrantonio\Documents\plataformasGrupo5TPFinal\plataformasGrupo5TPFinal\Views\My\Buscador.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
