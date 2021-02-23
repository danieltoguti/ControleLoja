using ControleLoja.Classes;
using ControleLoja.Data;
using ControleLoja.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleLoja.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _hCont;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _hCont = httpContextAccessor;
        }
        
        [Authorize] // AQUI LOGA TODO MUNDO PASSOU PELO LOGIN
        public IActionResult Index()
        {
            ViewData["Nome"] = CMetodos_Autenticacao.GET_DadosUser(_hCont, CMetodos_Autenticacao.eDadosUser.Nome);
            ViewData["Tipo"] = CMetodos_Autenticacao.GET_DadosUser(_hCont, CMetodos_Autenticacao.eDadosUser.Tipo);
            return View();
        }

        public async Task<IActionResult> Login()
        {
            await _hCont.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        public async Task<IActionResult> Logar(VendedorModel obj)
        {

            VendedorDB Vendedor = new VendedorDB();

            var resp = await Vendedor.ValidarNomeLoginAsync(obj, _hCont);

            if (resp)
            {
                return  RedirectToAction("index");
            }
            else
            {
                ViewData["Valida"] = "<div class='alert alert-warning text-center' role='alert'>Dados inválidos</div>";
            }
            return View("login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
