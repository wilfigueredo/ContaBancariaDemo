using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Repository
{
    public interface IContaRepository : IRepository<Conta>, IRepositoryWrite<Conta>
    {         
        Conta Depositar(Conta conta, double valor);
        IEnumerable<Conta> ObterPorSaldo(double valor);
        Conta Sacar(Conta conta, double valor);
        void RemoverContaPessoa(Guid Id);
        void BloquearConta(Guid Id);
        void AtivarConta(Guid Id);
    }
}
