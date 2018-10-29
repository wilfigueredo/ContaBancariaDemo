using WF.ContaBancaria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.Interface
{
    public interface IContaAppService : IDisposable
    {
        ContaViewModel Adicionar(ContaViewModel contaViewModel);
        DepositoViewModel Depositar(DepositoViewModel depositoViewModel);
        SaqueViewModel Sacar(SaqueViewModel saqueViewModel);
        SaqueViewModel ObterDadosSaque(Guid Id);
        DepositoViewModel ObterDadosDeposito(Guid Id);
        IEnumerable<ExtratoViewModel> ObterExtrato(Guid Id);
        IEnumerable<ExtratoViewModel> GerarExtratoPeriodo(Guid Id,DateTime dataInicial,DateTime dataFinal);
        ExtratoPeriodoViewModel ObterDadosExtratoPeriodo(Guid Id);
        double ConsultarSaldo(Guid Id);
        void BloquearConta(Guid Id);
        void AtivarConta(Guid Id);
        ContaViewModel ObterPorId(Guid Id);
        IEnumerable<ContaViewModel> ObterTodos();
        IEnumerable<ContaViewModel> ObterPorSaldo(double valor);
        ContaViewModel Atualizar(ContaViewModel contaViewModel);
        void Remover(Guid id);        
    }
}
