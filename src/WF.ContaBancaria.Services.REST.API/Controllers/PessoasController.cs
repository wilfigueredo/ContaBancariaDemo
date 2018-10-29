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
    public class PessoasController : ApiController
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        // GET: api/Pessoas
        [HttpGet]
        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return _pessoaAppService.ObterTodos();
        }

        // GET: api/Pessoas/5
        [HttpGet]
        public PessoaViewModel ObterPorId(Guid id)
        {
            return _pessoaAppService.ObterPorId(id);
        }

        // POST: api/Pessoas
        [HttpPost]
        public void Incluir([FromBody]PessoaViewModel pessoa)
        {
            _pessoaAppService.Adicionar(pessoa);
        }

        // PUT: api/Pessoas/5
        [HttpPut]
        public void Atualizar(Guid id, [FromBody]PessoaViewModel pessoaViewModel)
        {
            _pessoaAppService.Atualizar(pessoaViewModel);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            _pessoaAppService.Remover(id);
        }
    }
}
