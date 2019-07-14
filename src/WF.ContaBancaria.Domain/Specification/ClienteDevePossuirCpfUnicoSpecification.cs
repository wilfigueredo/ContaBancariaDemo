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
    public class ClienteDevePossuirCpfUnicoSpecification : ISpecification<Cliente>
    {

        private readonly IClienteRepository _ClienteRepository;

        public ClienteDevePossuirCpfUnicoSpecification(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }

        public bool IsSatisfiedBy(Cliente Cliente)
        {
            return  _ClienteRepository.ObterPorCpf(Cliente.CPF) == null;
        }
    }
}
