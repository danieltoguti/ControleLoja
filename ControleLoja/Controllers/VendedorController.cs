using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleLoja.Data;
using ControleLoja.Models;

namespace ControleLoja.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Valida"] = "";
            return View();
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
