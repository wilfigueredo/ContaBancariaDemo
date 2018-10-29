using WF.ContaBancaria.Domain.Interface.Repository;
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
    public class PessoaAptoParaCadastroValidation : Validator<Pessoa>
    {
        public PessoaAptoParaCadastroValidation(IPessoaRepository pessoaRepository)
        {
            var pessoaUnica = new PessoaDevePossuirCpfUnicoSpecification(pessoaRepository);

            base.Add("pessoaUnica", new Rule<Pessoa>(pessoaUnica, "Pessoa com cpf já cadastrado no banco"));
        }
    }
}
