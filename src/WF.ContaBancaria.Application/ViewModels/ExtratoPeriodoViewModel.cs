using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.ViewModels
{
    public class ExtratoPeriodoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [Display(Name ="Data Inicio")]
        [Required(ErrorMessage ="Preencha o campo data inicio")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicial { get; set; }

        [Display(Name = "Data Fim")]
        [Required(ErrorMessage = "Preencha o campo data fim")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFinal { get; set; }

        
    }
}
