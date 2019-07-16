using WF.ContaBancaria.Domain.Models;
using WF.ContaBancaria.Domain.Specification;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Interface.Repository;

namespace WF.ContaBancaria.Domain.Validation
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation(IClienteRepository ClienteRepository)
        {

            var ClienteUnica = new ClienteDevePossuirCpfUnicoSpecification(ClienteRepository);

            base.Add("ClienteUnica", new Rule<Cliente>(ClienteUnica, "Cliente com cpf já cadastrado no banco"));

            
        }
    }
}
