using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.ValueObject;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Specification
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente Cliente)
        {
            return CPF.Validar(Cliente.CPF);
        }
    }
}
