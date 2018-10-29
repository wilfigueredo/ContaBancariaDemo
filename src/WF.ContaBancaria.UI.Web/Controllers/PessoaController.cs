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
    public class PessoaController : BaseController
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        // GET: Pessoa
        public ActionResult Index(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return View(_pessoaAppService.ObterTodos());
            else
                return View(_pessoaAppService.ObterPorNome(nome));
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PessoaViewModel pessoaViewModel = _pessoaAppService.ObterPorId(id.Value);

            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pessoaViewModel);
            }
            pessoaViewModel = _pessoaAppService.Adicionar(pessoaViewModel);

            if (pessoaViewModel.ValidationResult.IsValid)
            {
                
               TempData["Sucesso"] = pessoaViewModel.ValidationResult.Message;
               return View(pessoaViewModel);              
            }
            PopularModelComErros(pessoaViewModel.ValidationResult);
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pessoaViewModel = _pessoaAppService.ObterPorId(id.Value);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pessoaViewModel);
            }

            pessoaViewModel = _pessoaAppService.Atualizar(pessoaViewModel);

            if (pessoaViewModel.ValidationResult.IsValid)
            {
                
                    TempData["Sucesso"] = pessoaViewModel.ValidationResult.Message;
                    return View(pessoaViewModel);
                
            }
            PopularModelComErros(pessoaViewModel.ValidationResult);
            return View(pessoaViewModel);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var pessoaViewModel = _pessoaAppService.ObterPorId(id.Value);
            if (pessoaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _pessoaAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
           _pessoaAppService.Dispose();
            
        }
    }
}
