using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Interface.Service;
using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Services;

namespace WF.ContaBancaria.Domain.Services
{
    public class TransacoesService : ITransacaoService
    {
        private readonly ITransacoesRepository _transacoesRepository;

        public TransacoesService(ITransacoesRepository transacaoRepository)
        {
            _transacoesRepository = transacaoRepository;
        }

        public Transacoes Adicionar(Transacoes transacoes)
        {
            if (!transacoes.IsValid())
                return transacoes;

            if (transacoes.ValidationResult.IsValid) { 
                transacoes.Valor = transacoes.Valor * -1;
                return _transacoesRepository.Adicionar(transacoes);
            }

            return transacoes;
        }

        public void Dispose()
        {
            _transacoesRepository.Dispose();
        }
    }
}
