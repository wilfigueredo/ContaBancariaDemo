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
    public class ContaConsistenteParaTransacoesValidation : Validator<Conta>
    {
        public ContaConsistenteParaTransacoesValidation()
        {
            var contaAtiva = new ContaDeveEstarAtivaParaSaqueSpecification();

            base.Add("contaAtiva", new Rule<Conta>(contaAtiva, "Conta bloqueada para transações"));
        }
    }
}
