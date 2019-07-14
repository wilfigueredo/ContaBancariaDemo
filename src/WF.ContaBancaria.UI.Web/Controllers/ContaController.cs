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
    public class ContaController : BaseController
    {

        private readonly IContaAppService _contaAppService;
        private readonly IClienteAppService _ClienteAppService;

        public ContaController(IContaAppService contaAppService, IClienteAppService ClienteAppService)
        {
            _contaAppService = contaAppService;
            _ClienteAppService = ClienteAppService;
        }
        // GET: Conta
        public ActionResult Index(string saldo)
        {
            if (string.IsNullOrEmpty(saldo))
                return View(_contaAppService.ObterTodos());
            else
                return View(_contaAppService.ObterPorSaldo(Convert.ToDouble(saldo)));   
            
        }

        // GET: Conta/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contaViewModel);
        }

        // GET: Conta/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_ClienteAppService.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: Conta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContaViewModel contaViewModel)
        {
            if (ModelState.IsValid)
            {
                contaViewModel.Id = Guid.NewGuid();
                _contaAppService.Adicionar(contaViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_contaAppService.ObterTodos(), "Id", "Nome", contaViewModel.ClienteId);
            return View(contaViewModel);
        }

        // GET: Conta/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(_ClienteAppService.ObterTodos(), "Id", "Nome", contaViewModel.ClienteId);
            return View(contaViewModel);
        }

        // POST: Conta/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContaViewModel contaViewModel)
        {
            if (ModelState.IsValid)
            {
                _contaAppService.Atualizar(contaViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_ClienteAppService.ObterTodos(), "Id", "Nome", contaViewModel.ClienteId);
            return View(contaViewModel);
        }

        // GET: Conta/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id.Value);
            if (contaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contaViewModel);
        }       

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ContaViewModel contaViewModel = _contaAppService.ObterPorId(id);
            _contaAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult Saque(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaqueViewModel SaqueViewModel = _contaAppService.ObterDadosSaque(id.Value);

            if (SaqueViewModel == null)
            {
                return HttpNotFound();
            }
            return View(SaqueViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Saque(SaqueViewModel saqueViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(saqueViewModel);
            }
            saqueViewModel = _contaAppService.Sacar(saqueViewModel);

            if (saqueViewModel.ValidationResult.IsValid)
            {

                TempData["Sucesso"] = saqueViewModel.ValidationResult.Message;
                return View(saqueViewModel);
            }
            PopularModelComErros(saqueViewModel.ValidationResult);
            return View(saqueViewModel);
        }

        public ActionResult Deposito(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepositoViewModel depositpViewModel = _contaAppService.ObterDadosDeposito(id.Value);
            if (depositpViewModel == null)
            {
                return HttpNotFound();
            }
            return View(depositpViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposito(DepositoViewModel depositoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(depositoViewModel);
            }
            depositoViewModel = _contaAppService.Depositar(depositoViewModel);

            if (depositoViewModel.ValidationResult.IsValid)
            {

                TempData["Sucesso"] = depositoViewModel.ValidationResult.Message;
                return View(depositoViewModel);
            }
            PopularModelComErros(depositoViewModel.ValidationResult);
            return View(depositoViewModel);
        }

        public ActionResult Ativar(Guid id)
        {
            _contaAppService.AtivarConta(id);
            return RedirectToAction("Index");
        }
        public ActionResult BloquearConta(Guid id)
        {
            _contaAppService.BloquearConta(id);
            return RedirectToAction("Index");
        }

        public ActionResult ObterExtrato(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var extratoViewModelViewModel = _contaAppService.ObterExtrato(id.Value);
            if (extratoViewModelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(extratoViewModelViewModel);
        }

        public ActionResult ExtratoPeriodo(Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var extratoViewModelViewModel = _contaAppService.ObterDadosExtratoPeriodo(id.Value);
            if (extratoViewModelViewModel == null)
            {
                return HttpNotFound();
            }

            return View(extratoViewModelViewModel);            
        }
        
        public ActionResult ConsultarExtratoPeriodo(ExtratoPeriodoViewModel extratoPeriodo)
        {
            var extrato = _contaAppService.GerarExtratoPeriodo(extratoPeriodo.Id, extratoPeriodo.DataInicial, extratoPeriodo.DataFinal);
            return PartialView(extrato);
        }

        protected override void Dispose(bool disposing)
        {
            _contaAppService.Dispose();
        }
    }
}
