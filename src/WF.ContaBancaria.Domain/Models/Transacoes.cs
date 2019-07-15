using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Enuns;

namespace WF.ContaBancaria.Domain.Models
{
    public class Transacoes :  Entity
    {
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public Guid ContaId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Conta Contas { get; set; }
    }
}
