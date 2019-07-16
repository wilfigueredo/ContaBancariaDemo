using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Repository
{
    public interface ITransacoesRepository : IRepository<Transacoes>, IRepositoryWrite<Transacoes>
    {
        IEnumerable<Transacoes> ObterExtrato(Guid Id);
        IEnumerable<Transacoes> ObterExtratoPeriodo(Guid Id, DateTime dataInicial, DateTime dataFinal);        
    }
}
