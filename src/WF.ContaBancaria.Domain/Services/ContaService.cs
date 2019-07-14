using WF.ContaBancaria.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Validation;
using DomainValidation.Validation;

namespace WF.ContaBancaria.Domain.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITransacoesRepository _transacoesRepository;

        public ContaService(IContaRepository contaRepository, ITransacoesRepository transacoesRepository)
        {
            _contaRepository = contaRepository;
            _transacoesRepository = transacoesRepository;
        }

        public Conta Adicionar(Conta conta)
        {
            return _contaRepository.Adicionar(conta);
        }

        public Conta Atualizar(Conta conta)
        {
            return _contaRepository.Atualizar(conta);
        }

        public Conta Sacar(Conta conta, Transacoes transacoes)
        {
            if (!conta.IsValid())
                return conta;

            conta.ValidationResult = new ContaAptaParaSaqueValidation(_transacoesRepository).Validate(transacoes);
                       

            return !conta.ValidationResult.IsValid ? conta : _contaRepository.Sacar(conta,transacoes.Valor);
        }

        public Conta Depositar(Conta conta, Transacoes transacoes)
        {
            if (!conta.IsValid())
                return conta;

            conta.ValidationResult = new ContaAptaParaDepositoValidation().Validate(transacoes);


            return !conta.ValidationResult.IsValid ? conta : _contaRepository.Depositar(conta, transacoes.Valor);
        }

        public void RemoverContaCliente(Guid Id)
        {
            _contaRepository.RemoverContaCliente(Id);
        }

        public void Dispose()
        {
            _contaRepository.Dispose();
        }        
    }
}
