using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Domain.Models;

namespace WF.ContaBancaria.Domain.Interface.Service
{
    public interface ITransacaoService : IDisposable
    {
        Transacoes Adicionar(Transacoes transacoes);
    }
}
