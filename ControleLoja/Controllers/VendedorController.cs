using ControleLoja.Classes;
using ControleLoja.Data;
using ControleLoja.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;



namespace ControleLoja.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IHttpContextAccessor _hCont;

        public VendedorController(IHttpContextAccessor httpContextAccessor)
        {
            _hCont = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewData["Nome"] = CMetodos_Autenticacao.GET_DadosUser(_hCont, CMetodos_Autenticacao.eDadosUser.Nome);
            ViewData["Valida"] = "";
            return View();
        }

        public IActionResult ListaVendedor()
        {
            ViewData["Nome"] = CMetodos_Autenticacao.GET_DadosUser(_hCont, CMetodos_Autenticacao.eDadosUser.Nome);
            VendedorDB Vend = new VendedorDB();
            var MLista = Vend.GetAll();
            return View(MLista);
        }

        public IActionResult Editar(int Id, string Nome, string Email, string Senha)
        {
            var model = new VendedorModel();
            model.Id = Id;
            model.Nome = Nome;
            model.Email = Email;
            model.Senha = Senha;
            ViewData["Valida"] = "";
            return View("index", model);
        }

        public IActionResult Excluir(int Id)
        {
            VendedorDB Vend = new VendedorDB();
            Vend.ExcluirDados(Id);
            return RedirectToAction("ListaVendedor", "Vendedor");
        }
        public IActionResult Salvar(VendedorModel obj)
        {
            string smgvalida = Validar(obj);
            if (smgvalida != "")
            {
                ViewData["Valida"] = smgvalida;
                return View("index");
            }

            VendedorDB Vendedor = new VendedorDB();

            if (obj.Id == 0)
            {

                if (Vendedor.InserirDados(obj))
                {
                    ViewData["Valida"] = "<div class='alert alert-success text-center' role='alert'>Vendedor(a) inserido(a) com sucesso!</div>";
                }
                else
                {
                    ViewData["Valida"] = "<div class='alert alert-danger text-center' role='alert'>Erro ao inserir Vendedor(a)!</div>";
                }
            }
            else
            {
                if (Vendedor.UpdateDados(obj))
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


        public string Validar(VendedorModel obj)
        {

            VendedorDB Func = new VendedorDB();

            if (String.IsNullOrEmpty(obj.Nome))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Digite o nome do vendedor!</div>";
            }

            if (Func.ValidarNome(obj))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Vendedor já cadastrado(a)!</div>";
            }

            return "";
        }
    }
}
