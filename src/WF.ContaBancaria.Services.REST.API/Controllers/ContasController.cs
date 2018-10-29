using WF.ContaBancaria.Application.Interface;
using WF.ContaBancaria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WF.ContaBancaria.Services.REST.PessoaAPI.Controllers
{
    [RoutePrefix("api/contas")]
    public class ContasController : ApiController
    {

        private readonly IContaAppService _contaAppService;

        public ContasController(IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
        }

        // GET: api/Contas
        [HttpGet]
        public IEnumerable<ContaViewModel> ObterTodos()
        {
            return _contaAppService.ObterTodos();
        }

        // GET: api/Contas/5
        [HttpGet]
        public ContaViewModel ObterPorId(Guid id)
        {
            return _contaAppService.ObterPorId(id);
        }

        // POST: api/Contas
        [HttpPost]
        public void CriarConta([FromBody] ContaViewModel contaViewModel)
        {
            _contaAppService.Adicionar(contaViewModel);
        }

        // PUT: api/Contas/5
        [HttpPut]
        public void Atualizar(Guid id, [FromBody] ContaViewModel contaViewModel)
        {
            _contaAppService.Atualizar(contaViewModel);
        }

        [HttpPut]
        [Route("Depositar/{id}")]
        public void Depositar(Guid id, [FromBody] DepositoViewModel depositoViewModel)
        {
            _contaAppService.Depositar(depositoViewModel);
        }

        [HttpPut]
        [Route("Sacar/{id}")]
        public void Sacar(Guid id, [FromBody] SaqueViewModel saqueViewModel)
        {
            _contaAppService.Sacar(saqueViewModel);
        }

        [HttpPut]
        [Route("BloquearConta/{id}")]
        public void BloquearConta(Guid id)
        {
            _contaAppService.BloquearConta(id);
        }

        [HttpGet]
        [Route("ObterExtrato/{id}")]
        public IEnumerable<ExtratoViewModel> ObterExtrato(Guid id)
        {
            return _contaAppService.ObterExtrato(id);
        }

        [HttpGet]
        [Route("ObterExtratoPeriodo")]
        public IEnumerable<ExtratoViewModel> ObterExtratoPeriodo([FromBody] ExtratoPeriodoViewModel extratoPeriodo)
        {
            return  _contaAppService.GerarExtratoPeriodo(extratoPeriodo.Id, extratoPeriodo.DataInicial, extratoPeriodo.DataFinal);
        }

        [HttpGet]
        [Route("ObterSaldo/{id}")]
        public double ObterSaldo(Guid Id)
        {
            return _contaAppService.ConsultarSaldo(Id);
        }

        // DELETE: api/Contas/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            _contaAppService.Remover(id);
        }
    }
}
