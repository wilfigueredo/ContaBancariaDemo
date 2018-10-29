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
    public class PessoaDevePossuirCpfUnicoSpecification : ISpecification<Pessoa>
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaDevePossuirCpfUnicoSpecification(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            return  _pessoaRepository.ObterPorCpf(pessoa.CPF) == null;
        }
    }
}
