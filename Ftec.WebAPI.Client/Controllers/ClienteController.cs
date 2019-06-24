using Ftec.WebAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ftec.WebAPI.Client.Controllers
{
    public class ClienteController : Controller
    {
        private API.APIHttpClient clienteHttp;

        public ClienteController()
        {
            clienteHttp = new API.APIHttpClient("http://localhost:51613/api/");
        }

        public ActionResult Index()
        {
            var clientes = clienteHttp.Get<List<Cliente>>(@"cliente");

            return View(clientes);
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Editar(Guid id)
        {
            //Pesquisa o livro na API
            var cliente = clienteHttp.Get<Cliente>(string.Format(@"cliente/{0}", id.ToString()));

            ViewBag.cliente = cliente;

            return View();
        }

        [HttpPost]
        public ActionResult ProcessarGravacaoPost(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var id = clienteHttp.Post<Cliente>(@"cliente/", cliente);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo", cliente);
            }
        }

        [HttpPost]
        public ActionResult ProcessarUpdatePost(Cliente cliente)
        {
            var id = clienteHttp.Put<Cliente>(@"cliente/", cliente.Id, cliente);

            return RedirectToAction("Index");
        }
    }
}