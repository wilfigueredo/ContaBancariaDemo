using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Specification
{
    public class ContaDeveTerSaldoParaSaqueSpecification : ISpecification<Transacoes>
    {
        private readonly ITransacoesRepository _transacaoRepository;

        public ContaDeveTerSaldoParaSaqueSpecification(ITransacoesRepository transacoesRepository)
        {
            _transacaoRepository = transacoesRepository;
        }

        public bool IsSatisfiedBy(Transacoes transacoes)
        {
            return _transacaoRepository.TemSaldoParaSaque(transacoes);
        }
    }
}
