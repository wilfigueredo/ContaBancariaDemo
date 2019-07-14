using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Infra.Data.Context;

namespace WF.ContaBancaria.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContaContext context) : base(context)
        {
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(p => p.CPF == cpf).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterPorNome(string nome)
        {
            return Buscar(p => p.Nome.Contains(nome));
        }       
    }
}
