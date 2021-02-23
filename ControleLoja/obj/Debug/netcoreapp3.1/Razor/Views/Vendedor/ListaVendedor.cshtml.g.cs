#pragma checksum "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39745102c1ced81905c4bfcef8516a7779885ceb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendedor_ListaVendedor), @"mvc.1.0.view", @"/Views/Vendedor/ListaVendedor.cshtml")]
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
#line 1 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\_ViewImports.cshtml"
using ControleLoja;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\_ViewImports.cshtml"
using ControleLoja.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39745102c1ced81905c4bfcef8516a7779885ceb", @"/Views/Vendedor/ListaVendedor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c6eac45199927479633b0d5f73e48b920ab6adc", @"/Views/_ViewImports.cshtml")]
    public class Views_Vendedor_ListaVendedor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VendedorModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <table class=""table"">
        <tr>
            <th><h2>Lista de Vendedores</h2></th>
            <th></th>
            <th></th>
            <th></th>
            <th class=""text-sm-right""><button class=""btn btn-primary"" type=""button"" onclick=""window.location.href ='/vendedor/index'"">Novo</button><th>
        </tr>
    </table>
");
#nullable restore
#line 16 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
     if (Model.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped table-condensed table-hover"">

            <thead>
                <tr class=""container"">
                    <th>Código</th>
                    <th>Nome</th>
                    <th>Email</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 30 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td style=\"height:10px\">");
#nullable restore
#line 33 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
                                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 34 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
                       Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 35 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
                       Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td><button type=\"button\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1119, "\"", 1232, 9);
            WriteAttributeValue("", 1129, "window.location.href=\'/vendedor/editar?Id=", 1129, 42, true);
#nullable restore
#line 36 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
WriteAttributeValue("", 1171, item.Id, 1171, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1179, "&Nome=", 1179, 6, true);
#nullable restore
#line 36 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
WriteAttributeValue("", 1185, item.Nome, 1185, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1195, "&Email=", 1195, 7, true);
#nullable restore
#line 36 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
WriteAttributeValue("", 1202, item.Email, 1202, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1213, "&senha=", 1213, 7, true);
#nullable restore
#line 36 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
WriteAttributeValue("", 1220, item.Senha, 1220, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1231, "\'", 1231, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button></td>\n                        <td><button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1327, "\"", 1389, 3);
            WriteAttributeValue("", 1337, "window.location.href=\'/vendedor/excluir?Id=", 1337, 43, true);
#nullable restore
#line 37 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
WriteAttributeValue("", 1380, item.Id, 1380, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1388, "\'", 1388, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Excluir</button></td>\n                    </tr>\n");
#nullable restore
#line 39 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n");
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-primary\" role=\"alert\">\n            Sem Registros!\n        </div>\n");
#nullable restore
#line 48 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Vendedor\ListaVendedor.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VendedorModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
