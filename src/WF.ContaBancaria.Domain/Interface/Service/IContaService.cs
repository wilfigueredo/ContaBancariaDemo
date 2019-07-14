using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Service
{
    public interface IContaService : IDisposable
    {
        Conta Adicionar(Conta conta);
        Conta Atualizar(Conta conta);
        Conta Sacar(Conta conta, Transacoes transacoes);
        void RemoverContaCliente(Guid Id);
        Conta Depositar(Conta conta, Transacoes transacoes);

    }
}
