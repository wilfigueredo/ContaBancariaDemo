using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Repository
{
    public interface IClienteRepository : IRepository<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        IEnumerable<Cliente> ObterPorNome(string nome);
    }
}
