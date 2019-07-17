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
    public class TransacaoValidaValidation : Validator<Transacoes>
    {
        public TransacaoValidaValidation()
        {
            var valorPositivo = new ValorParaTransacaoDeveSerPositivoSpecification();
            var valorIgualAZero = new ValorNaoPodeSerIgualAZeroSpecification();

            base.Add("valorPositivo", new Rule<Transacoes>(valorPositivo, "Valor deve ser positivo"));
            base.Add("valorIgualAZero", new Rule<Transacoes>(valorIgualAZero, "Valor não pode ser igual a zero"));
        }
    }
}
