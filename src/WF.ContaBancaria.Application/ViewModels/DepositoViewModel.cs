using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.ViewModels
{
    public class DepositoViewModel
    {
        public Guid Id { get; set; }
        public double Saldo { get; set; }

        [Display(Name = "Limite de Saque Diario")]
        public double LimiteSaqueDiario { get; set; }

        [Display(Name = "Tipo de conta")]
        public int TipoConta { get; set; }

        [Required(ErrorMessage = "Preencha o campo valor do deposito")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        [Display(Name = "Valor do deposito")]
        public double ValorDeposito { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
