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
        public ClienteAptoParaCadastroValidation(IClienteRepository ClienteRepository)
        {
            var ClienteUnica = new ClienteDevePossuirCpfUnicoSpecification(ClienteRepository);

            base.Add("ClienteUnica", new Rule<Cliente>(ClienteUnica, "Cliente com cpf já cadastrado no banco"));
        }
    }
}
