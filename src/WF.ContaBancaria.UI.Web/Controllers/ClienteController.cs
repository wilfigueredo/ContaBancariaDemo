using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WF.ContaBancaria.Application.ViewModels;
using WF.ContaBancaria.Application.Interface;

namespace WF.ContaBancaria.UI.Web.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _ClienteAppService;

        public ClienteController(IClienteAppService ClienteAppService)
        {
            _ClienteAppService = ClienteAppService;
        }

        // GET: Cliente
        public ActionResult Index(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return View(_ClienteAppService.ObterTodos());
            else
                return View(_ClienteAppService.ObterPorNome(nome));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteViewModel ClienteViewModel = _ClienteAppService.ObterPorId(id.Value);

            if (ClienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ClienteViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel ClienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ClienteViewModel);
            }
            ClienteViewModel = _ClienteAppService.Adicionar(ClienteViewModel);

            if (ClienteViewModel.ValidationResult.IsValid)
            {
                
               TempData["Sucesso"] = ClienteViewModel.ValidationResult.Message;
               return View(ClienteViewModel);              
            }
            PopularModelComErros(ClienteViewModel.ValidationResult);
            return View(ClienteViewModel);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ClienteViewModel = _ClienteAppService.ObterPorId(id.Value);
            if (ClienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ClienteViewModel);
        }

        // POST: Cliente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel ClienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ClienteViewModel);
            }

            ClienteViewModel = _ClienteAppService.Atualizar(ClienteViewModel);

            if (ClienteViewModel.ValidationResult.IsValid)
            {
                
                    TempData["Sucesso"] = ClienteViewModel.ValidationResult.Message;
                    return View(ClienteViewModel);
                
            }
            PopularModelComErros(ClienteViewModel.ValidationResult);
            return View(ClienteViewModel);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var ClienteViewModel = _ClienteAppService.ObterPorId(id.Value);
            if (ClienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ClienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _ClienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
           _ClienteAppService.Dispose();
            
        }
    }
}
