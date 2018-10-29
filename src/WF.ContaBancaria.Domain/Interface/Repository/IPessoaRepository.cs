using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>, IRepositoryWrite<Pessoa>
    {
        Pessoa ObterPorCpf(string cpf);
        IEnumerable<Pessoa> ObterPorNome(string nome);
    }
}
