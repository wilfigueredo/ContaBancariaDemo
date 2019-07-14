using WF.ContaBancaria.Application.Interface;
using WF.ContaBancaria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WF.ContaBancaria.Services.REST.ClienteAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _ClienteAppService;

        public ClientesController(IClienteAppService ClienteAppService)
        {
            _ClienteAppService = ClienteAppService;
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _ClienteAppService.ObterTodos();
        }

        // GET: api/Clientes/5
        [HttpGet]
        public ClienteViewModel ObterPorId(Guid id)
        {
            return _ClienteAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        [HttpPost]
        public void Incluir([FromBody]ClienteViewModel Cliente)
        {
            _ClienteAppService.Adicionar(Cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut]
        public void Atualizar(Guid id, [FromBody]ClienteViewModel ClienteViewModel)
        {
            _ClienteAppService.Atualizar(ClienteViewModel);
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            _ClienteAppService.Remover(id);
        }
    }
}
