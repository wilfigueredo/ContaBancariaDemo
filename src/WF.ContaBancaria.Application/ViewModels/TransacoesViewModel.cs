using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Application.Enuns;

namespace WF.ContaBancaria.Application.ViewModels
{
    public class TransacoesViewModel
    {
        public TransacoesViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public double Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public TipoTransacao TipoTransacao { get; set; }

        public Guid ContaId { get; set; }

        public ContaViewModel Contas { get; set; }

    }
}
