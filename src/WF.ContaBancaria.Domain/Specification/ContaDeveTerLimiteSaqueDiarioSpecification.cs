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
    public class ContaDeveTerLimiteSaqueDiarioSpecification : ISpecification<Transacoes>
    {
        private readonly ITransacoesRepository _TransacaoRepository;

        public ContaDeveTerLimiteSaqueDiarioSpecification(ITransacoesRepository transacoesRepository)
        {
            _TransacaoRepository = transacoesRepository;
        }
        public bool IsSatisfiedBy(Transacoes transacoes)
        {
            return _TransacaoRepository.TemLimiteSaqueDiario(transacoes);
        }
    }
}
