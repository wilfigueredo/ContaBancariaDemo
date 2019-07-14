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
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um cpf inválido"));
        }
    }
}
