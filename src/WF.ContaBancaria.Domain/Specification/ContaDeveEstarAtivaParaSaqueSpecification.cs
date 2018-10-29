using WF.ContaBancaria.Domain.Models;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Specification
{
    public class ContaDeveEstarAtivaParaSaqueSpecification : ISpecification<Conta>
    {
        public bool IsSatisfiedBy(Conta conta)
        {
            return conta.Ativo;
        }
    }
}
