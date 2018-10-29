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
    public class PessoaAppService : AppServices, IPessoaAppService
    {

        private readonly IPessoaRepository _pessoaRepository;
        private readonly IContaService _contaService;
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaRepository pessoaRepository,
            IPessoaService pessoaService, IContaService contaService,
            IUnitOfWork uow) : base(uow)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
            _contaService = contaService;
        }
        public PessoaViewModel Adicionar(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Mapper.Map<Pessoa>(pessoaViewModel);            

            var pessoaRet = _pessoaService.Adicionar(pessoa);

            if (pessoa.ValidationResult.IsValid)
            {
                Commit();
                pessoaRet.ValidationResult.Message = "Pessoa salva com sucesso";
            }           

            pessoaViewModel = Mapper.Map<PessoaViewModel>(pessoaRet);

            return pessoaViewModel;
        }

        public PessoaViewModel Atualizar(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Mapper.Map<Pessoa>(pessoaViewModel);

            var pessoaRet =  _pessoaService.Atualizar(pessoa);

            if (pessoa.ValidationResult.IsValid)
            {
                Commit();
                pessoaRet.ValidationResult.Message = "Pessoa Editada com sucesso";
            }

            pessoaViewModel = Mapper.Map<PessoaViewModel>(pessoaRet);

            return pessoaViewModel;
        }

        public void Remover(Guid id)
        {
            _contaService.RemoverContaPessoa(id);
            _pessoaRepository.Remover(id);
            Commit();
        }

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterTodos());
        }

        public PessoaViewModel ObterPorId(Guid Id)
        {
            return Mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorId(Id));
        }

        public IEnumerable<PessoaViewModel> ObterPorCpf(string cpf)
        {
            return Mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterPorCpf(cpf));
        }

        public IEnumerable<PessoaViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterPorNome(nome));
        }
        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }

        
    }
}
