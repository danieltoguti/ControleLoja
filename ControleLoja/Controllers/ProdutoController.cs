using ControleLoja.Data;
using ControleLoja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Controllers
{
    [Authorize(Roles = "Logado, ADM")] // AQUI LOGA TODO MUNDO QUE TIVER O ROLES "Logado,ADM"
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ProdutoDB Cat = new ProdutoDB();
            ProdutoDB Gen = new ProdutoDB();

            ViewData["LTCategorias"] = Cat.GetCategoria();
            ViewData["LTGenero"] = Gen.GetGenero();

            ViewData["Valida"] = "";
            return View();
        }

        public IActionResult ListaProduto()
        {
            ProdutoDB Prod = new ProdutoDB();
            var MLista = Prod.GetAll();
            return View(MLista);
        }

        public IActionResult Editar(int Id, string Nome, double PrecoCusto, double PrecoSugerido, int Quantidade, string Categoria, string Genero, DateTime Validade)
        {
            var model = new ProdutoModelVW();
            model.Id = Id;
            model.Nome = Nome;
            model.Preco_Custo = PrecoCusto;
            model.Preco_Sugerido = PrecoSugerido;
            model.Qtd = Quantidade;
            model.Categoria = Categoria;
            model.Genero = Genero;
            model.Validade = Validade;
            ViewData["Valida"] = "";
            return View("index", model);
        }

        public IActionResult Excluir(int Id)
        {
            ProdutoDB Cid = new ProdutoDB();
            Cid.ExcluirDados(Id);
            return RedirectToAction("ListaProduto", "Produto");
        }

        public IActionResult Salvar(ProdutoModel obj)
        {
            string smgvalida = Validar(obj);
            if (smgvalida != "")
            {
                ViewData["Valida"] = smgvalida;
                return View("index");
            }

            ProdutoDB Prod = new ProdutoDB();

            if (obj.Id == 0)
            {

                if (Prod.InserirDados(obj))
                {
                    ViewData["Valida"] = "<div class='alert alert-success text-center' role='alert'>Produto inserido(a) com sucesso!</div>";
                }
                else
                {
                    ViewData["Valida"] = "<div class='alert alert-danger text-center' role='alert'>Erro ao inserir produto!</div>";
                }
            }
            else
            {
                if (Prod.UpdateDados(obj))
                {
                    ViewData["Valida"] = "<div class='alert alert-success text-center' role='alert'Atualizado com sucesso!</div>";
                }
                else
                {
                    ViewData["Valida"] = "<div class='alert alert-danger text-center' role='alert'>Erro ao atualizar!</div>";
                }
            }

            return View("index");
        }


        public string Validar(ProdutoModel obj)
        {

            ProdutoDB Func = new ProdutoDB();

            if (String.IsNullOrEmpty(obj.Nome))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Digite o nome do produto</div>";
            }

            if (Func.ValidarNome(obj))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Produto já cadastrado(a)!</div>";
            }

            return "";
        }
    }
}

