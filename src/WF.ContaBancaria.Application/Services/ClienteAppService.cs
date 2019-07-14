using WF.ContaBancaria.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Application.ViewModels;
using WF.ContaBancaria.Domain.Interface.Repository;
using AutoMapper;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Interface.Service;
using WF.ContaBancaria.Infra.Data.UoW;

namespace WF.ContaBancaria.Application.Services
{
    public class ClienteAppService : AppServices, IClienteAppService
    {

        private readonly IClienteRepository _ClienteRepository;
        private readonly IContaService _contaService;
        private readonly IClienteService _ClienteService;

        public ClienteAppService(IClienteRepository ClienteRepository,
            IClienteService ClienteService, IContaService contaService,
            IUnitOfWork uow) : base(uow)
        {
            _ClienteRepository = ClienteRepository;
            _ClienteService = ClienteService;
            _contaService = contaService;
        }
        public ClienteViewModel Adicionar(ClienteViewModel ClienteViewModel)
        {
            var Cliente = Mapper.Map<Cliente>(ClienteViewModel);            

            var ClienteRet = _ClienteService.Adicionar(Cliente);

            if (Cliente.ValidationResult.IsValid)
            {
                Commit();
                ClienteRet.ValidationResult.Message = "Cliente salva com sucesso";
            }           

            ClienteViewModel = Mapper.Map<ClienteViewModel>(ClienteRet);

            return ClienteViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel ClienteViewModel)
        {
            var Cliente = Mapper.Map<Cliente>(ClienteViewModel);

            var ClienteRet =  _ClienteService.Atualizar(Cliente);

            if (Cliente.ValidationResult.IsValid)
            {
                Commit();
                ClienteRet.ValidationResult.Message = "Cliente Editada com sucesso";
            }

            ClienteViewModel = Mapper.Map<ClienteViewModel>(ClienteRet);

            return ClienteViewModel;
        }

        public void Remover(Guid id)
        {
            _contaService.RemoverContaCliente(id);
            _ClienteRepository.Remover(id);
            Commit();
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_ClienteRepository.ObterTodos());
        }

        public ClienteViewModel ObterPorId(Guid Id)
        {
            return Mapper.Map<ClienteViewModel>(_ClienteRepository.ObterPorId(Id));
        }

        public IEnumerable<ClienteViewModel> ObterPorCpf(string cpf)
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_ClienteRepository.ObterPorCpf(cpf));
        }

        public IEnumerable<ClienteViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_ClienteRepository.ObterPorNome(nome));
        }
        public void Dispose()
        {
            _ClienteRepository.Dispose();
        }

        
    }
}
