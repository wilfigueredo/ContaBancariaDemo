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
        IEnumerable<Conta> ObterPorSaldo(double valor);        
        void RemoverContaCliente(Guid Id);        
    }
}
