using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Specification;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Validation
{
    public class PessoaEstaConsistenteValidation : Validator<Pessoa>
    {
        public PessoaEstaConsistenteValidation()
        {
            var CPFPessoa = new PessoaDeveTerCpfValidoSpecification();

            base.Add("CPFPessoa", new Rule<Pessoa>(CPFPessoa, "Pessoa informou um cpf inválido"));
        }
    }
}
