using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Enuns;
using WF.ContaBancaria.Domain.Validation;

namespace WF.ContaBancaria.Domain.Models
{
    public class Transacoes :  Entity
    {
        public Transacoes(double valor,TipoTransacao tipoTransacao,Guid contaId)
        {
            if(tipoTransacao == TipoTransacao.Saque)
                Valor = valor * -1;
            Valor = valor;
            TipoTransacao = tipoTransacao;
            ContaId = contaId;
            DataCadastro = DateTime.Now;
        }

        public double Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public TipoTransacao TipoTransacao { get; set; }
        public Guid ContaId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Conta Conta { get; set; }

        public bool IsValid()
        {
            ValidationResult = new TransacaoValidaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
