using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Models;

namespace WF.ContaBancaria.Domain.Specification
{
    public class ValorNaoPodeSerIgualAZeroSpecification : ISpecification<Transacoes>
    {
        public bool IsSatisfiedBy(Transacoes transacoes)
        {
            return transacoes.Valor == 0;
        }
    }
}
