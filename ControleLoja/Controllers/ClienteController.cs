﻿using ControleLoja.Data;
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
    [Authorize(Roles = "ADM2")]  // AQUI LOGA TODO MUNDO QUE TEM O ROLE "ADM2" no caso ninguem então não vai deixar entrar na pagina
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Valida"] = "";
            return View();
        }


        public IActionResult ListaCliente()
        {
            ClienteDB Cliente = new ClienteDB();
            var MLista = Cliente.GetAll();
            return View(MLista);
        }

        public IActionResult Editar(int Id, string Nome, string Cidade, string Cel, string Email)
        {
            var model = new ClienteModel();
            model.Id = Id;
            model.Nome = Nome;
            model.Cidade = Cidade;
            model.Cel = Cel;
            model.Email = Email;
            ViewData["Valida"] = "";
            return View("index", model);
        }

        public IActionResult Excluir(int Id)
        {
            ClienteDB Cid = new ClienteDB();
            Cid.ExcluirDados(Id);
            return RedirectToAction("ListaCliente", "Cliente");
        }

        public IActionResult Salvar(ClienteModel obj)
        {
            string smgvalida = Validar(obj);
            if (smgvalida != "")
            {
                ViewData["Valida"] = smgvalida;
                return View("index");
            }

            ClienteDB Cliente = new ClienteDB();

            if (obj.Id == 0)
            {

                if (Cliente.InserirDados(obj))
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
                if (Cliente.UpdateDados(obj))
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


        public string Validar(ClienteModel obj)
        {

            ClienteDB Func = new ClienteDB();

            if (String.IsNullOrEmpty(obj.Nome))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Digite o nome do cliente</div>";
            }

            if (Func.ValidarNome(obj))
            {
                return "<div class='alert alert-warning text-center' role='alert'>Cliente já cadastrado(a)!</div>";
            }

            return "";
        }
    }
}
