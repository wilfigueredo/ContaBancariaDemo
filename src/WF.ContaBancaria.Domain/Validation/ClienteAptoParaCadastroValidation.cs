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
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteMaiorDeIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um cpf inválido"));
            base.Add("clienteMaiorDeIdade", new Rule<Cliente>(clienteMaiorDeIdade, "Cliente informou um cpf inválido"));
        }
    }
}
