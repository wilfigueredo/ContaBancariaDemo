using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Infra.Data.UoW;
using WF.ContaBancaria.Application.Interface;
using WF.ContaBancaria.Application.ViewModels;
using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Interface.Service;
using AutoMapper;
using WF.ContaBancaria.Domain.Models;

namespace WF.ContaBancaria.Application.Services
{
    public class ContaAppService : AppServices, IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITransacoesRepository _transacoesRepository;
        private readonly IContaService _contaService;

        public ContaAppService(IContaRepository contaRepository,
                               IContaService contaService,
                               ITransacoesRepository transacoesRepository,
                               IUnitOfWork uow) : base(uow)
        {
            _contaRepository = contaRepository;
            _contaService = contaService;
            _transacoesRepository = transacoesRepository;
        }

        public ContaViewModel Adicionar(ContaViewModel contaViewModel)
        {
            var conta = Mapper.Map<Conta>(contaViewModel);

            var ClienteRet = _contaService.Adicionar(conta);

            Commit();

            return contaViewModel;
        }

        public ContaViewModel Atualizar(ContaViewModel contaViewModel)
        {
            var conta = Mapper.Map<Conta>(contaViewModel);

            var ClienteRet = _contaService.Atualizar(conta);

            Commit();

            return contaViewModel;
        }

        public void AtivarConta(Guid Id)
        {
            _contaRepository.AtivarConta(Id);
            Commit();
        }

        

        public void BloquearConta(Guid Id)
        {
            _contaRepository.BloquearConta(Id);
            Commit();
        }

        public SaqueViewModel Sacar(SaqueViewModel saqueViewModel)
        {
            var conta = Mapper.Map<ContaViewModel>(saqueViewModel);
            conta = ObterPorId(conta.Id);
            var contaR = Mapper.Map<Conta>(conta);
            Transacoes transacoes = new Transacoes();
            transacoes.ContaId = conta.Id;
            transacoes.Valor = saqueViewModel.ValorSaque;
            
            var contaRet = _contaService.Sacar(contaR,transacoes);
            transacoes.Valor = transacoes.Valor * -1;
            _transacoesRepository.Adicionar(transacoes);

            if (contaR.ValidationResult.IsValid)
            { 
                Commit();
                contaR.ValidationResult.Message = "Saque realizado com sucesso!";
            }
           
            saqueViewModel = Mapper.Map<SaqueViewModel>(contaRet);
            
            return saqueViewModel;
        }

        public DepositoViewModel Depositar(DepositoViewModel depositoViewModel)
        {

            var conta = Mapper.Map<ContaViewModel>(depositoViewModel);
            conta = ObterPorId(conta.Id);
            var contaR = Mapper.Map<Conta>(conta);
            Transacoes transacoes = new Transacoes();
            transacoes.ContaId = conta.Id;
            transacoes.Valor = depositoViewModel.ValorDeposito;

            var contaRet = _contaService.Depositar(contaR, transacoes);
            
            _transacoesRepository.Adicionar(transacoes);

            if (contaR.ValidationResult.IsValid)
            {
                Commit();
                contaR.ValidationResult.Message = "Deposito realizado com sucesso!";
            }

            depositoViewModel = Mapper.Map<DepositoViewModel>(contaRet);

            return depositoViewModel;
        }

        public void Remover(Guid id)
        {
            _contaRepository.Remover(id);
            Commit();
        }             

        public ContaViewModel ObterPorId(Guid Id)
        {
            return Mapper.Map<ContaViewModel>(_contaRepository.ObterPorId(Id));
        }

        public IEnumerable<ContaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.ObterTodos());
        }
        public SaqueViewModel ObterDadosSaque(Guid Id)
        {
            return Mapper.Map<SaqueViewModel>(_contaRepository.ObterPorId(Id));
        }

        public DepositoViewModel ObterDadosDeposito(Guid Id)
        {
            return Mapper.Map<DepositoViewModel>(_contaRepository.ObterPorId(Id));
        }

        public IEnumerable<ContaViewModel> ObterPorSaldo(double valor)
        {
            return Mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.ObterPorSaldo(valor));
        }

        public IEnumerable<ExtratoViewModel> ObterExtrato(Guid Id)
        {
            return Mapper.Map<IEnumerable<ExtratoViewModel>>(_transacoesRepository.ObterExtrato(Id));
        }

        public ExtratoPeriodoViewModel ObterDadosExtratoPeriodo(Guid Id)
        {
            var conta = _contaRepository.ObterPorId(Id);
            ExtratoPeriodoViewModel extratoPeriodo = new ExtratoPeriodoViewModel();
            extratoPeriodo.Id = conta.Id;
            extratoPeriodo.Nome = conta.Cliente.Nome;
            return extratoPeriodo;
        }

        public IEnumerable<ExtratoViewModel> GerarExtratoPeriodo(Guid Id, DateTime dataInicial, DateTime dataFinal)
        {
            return Mapper.Map<IEnumerable<ExtratoViewModel>>(_transacoesRepository.ObterExtratoPeriodo(Id, dataInicial, dataFinal));
        }

        public double ConsultarSaldo(Guid Id)
        {
            var conta = ObterPorId(Id);
            double saldo = conta.Saldo;

            return saldo;
        }

        public void Dispose()
        {
            _contaRepository.Dispose();
        }       
    }
}
