#pragma checksum "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91bdd324a59717968e71e096572aaf5749067234"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_ListaProduto), @"mvc.1.0.view", @"/Views/Produto/ListaProduto.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91bdd324a59717968e71e096572aaf5749067234", @"/Views/Produto/ListaProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1200370c17081450f1a721a25815bd9c4b43d55f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_ListaProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ClienteModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h4>Lista de Clientes</h4>\r\n    <button class=\"btn btn-block btn-primary\" type=\"button\" onclick=\"window.location.href =\'/Cliente/index\'\">Cadastrar Cliente</button>\r\n");
#nullable restore
#line 9 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
     if (Model.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table"">

            <thead>
                <tr>
                    <th>Código</th>
                    <th>Nome</th>
                    <th>Cidade</th>
                    <th>Celular</th>
                    <th>Email</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 27 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                       Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                       Write(item.Cidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                       Write(item.Cel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                       Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 36 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                             try
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <img src=\"https://static.natura.com/cdn/farfuture/ev8ZcHHOWfDG05LHxYgrz7BBlGBN1u2wBZpse0gtkE0/1584727806/sites/default/files/products/72147_1_2.jpg\" width=\"150\" height=\"150\" />\r\n");
#nullable restore
#line 39 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                            }
                            catch { }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td><button type=\"button\" class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1553, "\"", 1681, 11);
            WriteAttributeValue("", 1563, "window.location.href=\'/cliente/editar?Id=", 1563, 41, true);
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1604, item.Id, 1604, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1612, "&Nome=", 1612, 6, true);
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1618, item.Nome, 1618, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1628, "&Cidade=", 1628, 8, true);
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1636, item.Cidade, 1636, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1648, "&Cel=", 1648, 5, true);
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1653, item.Cel, 1653, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1662, "&Email=", 1662, 7, true);
#nullable restore
#line 42 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1669, item.Email, 1669, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1680, "\'", 1680, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button></td>\r\n                        <td><button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1777, "\"", 1838, 3);
            WriteAttributeValue("", 1787, "window.location.href=\'/cliente/excluir?Id=", 1787, 42, true);
#nullable restore
#line 43 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
WriteAttributeValue("", 1829, item.Id, 1829, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1837, "\'", 1837, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Excluir</button></td>\r\n                    </tr>\r\n");
#nullable restore
#line 45 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 48 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-primary\" role=\"alert\">\r\n            Sem Registros!\r\n        </div>\r\n");
#nullable restore
#line 54 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <button class=\"btn btn-block btn-primary\" type=\"button\" onclick=\"window.location.href =\'/Cliente/index\'\">Cadastrar Cliente</button>\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n \r\n\r\n</div >\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ClienteModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591