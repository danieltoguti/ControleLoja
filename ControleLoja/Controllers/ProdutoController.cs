using ControleLoja.Data;
using ControleLoja.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
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
            var model = new ProdutoModel();
            model.Id = Id;
            model.Nome = Nome;
            model.PrecoCusto = PrecoCusto;
            model.PrecoSugerido = PrecoSugerido;
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
                    ViewData["Valida"] = "<div class='alert alert-success text-center' role='alert'>Cliente inserido(a) com sucesso!</div>";
                }
                else
                {
                    ViewData["Valida"] = "<div class='alert alert-danger text-center' role='alert'>Erro ao inserir Cliente!</div>";
                }
            }
            else
            {
                if (Prod.UpdateDados(obj))
                {
                    ViewData["Valida"] = "<div class='alert alert-success text-center' role='alert'>Cadastro atualizado com sucesso!</div>";
                }
                else
                {
                    ViewData["Valida"] = "<div class='alert alert-danger text-center' role='alert'>Erro ao atualizar Cadastro!</div>";
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

