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
    public class ContaAptaParaDepositoValidation : Validator<Transacoes>
    {
        public ContaAptaParaDepositoValidation()
        {
            var valorPositovo = new ValorParaDepositoDeveSerPositivoSpecification();

            base.Add("valorPositovo", new Rule<Transacoes>(valorPositovo, "Valor deve ser positivo"));
        }
    }
}
