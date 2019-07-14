using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.ViewModels
{
    public class ContaViewModel
    {

        public ContaViewModel()
        {
            Id = Guid.NewGuid();
            Saldo = 0.0;
            TipoConta = 0;
            Ativo = true;
        }

        public Guid Id { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Valor Invalido")]
        [Required(ErrorMessage = "Preencha o campo Limite de Saldo")]
        public double Saldo { get; set; }

        [Display(Name = "Limite de Saque Diario")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Valor Invalido")]
        [Required(ErrorMessage = "Preencha o campo Limite de Saque Diario")]
        public double LimiteSaqueDiario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Tipo de conta")]
        [Required(ErrorMessage = "Preencha o campo Tipo de conta")]
        public int TipoConta { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public virtual Guid? ClienteId { get; set; }
        public virtual ICollection<TransacoesViewModel> Transacoes { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }

    }
}
