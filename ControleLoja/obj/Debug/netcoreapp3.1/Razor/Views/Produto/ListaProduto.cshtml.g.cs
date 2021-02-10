#pragma checksum "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2fbcb2735f5a7e106d6b55e67df9707311203ac"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2fbcb2735f5a7e106d6b55e67df9707311203ac", @"/Views/Produto/ListaProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1200370c17081450f1a721a25815bd9c4b43d55f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_ListaProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProdutoModel>>
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
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h4>Lista de Produto</h4>\r\n\r\n");
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
                    <th>Preço de Custo</th>
                    <th>Preço Sugerido</th>
                    <th>Quantidade</th>
                    <th>Categoria</th>
                    <th>Genero</th>
                    <th>Validade</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 26 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.PrecoCusto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.PrecoSugerido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.Qtd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.Categoria);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                   Write(item.Genero);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 40 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 43 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-primary\" role=\"alert\">\r\n            Sem Registros!\r\n        </div>\r\n");
#nullable restore
#line 49 "C:\Users\danie\Documents\GitHub\ControleLoja\ControleLoja\Views\Produto\ListaProduto.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <button class=\"btn btn-block btn-primary\" type=\"button\" onclick=\"window.location.href =\'/produto/index\'\">Cadastrar Cliente</button>\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n\r\n\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProdutoModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
