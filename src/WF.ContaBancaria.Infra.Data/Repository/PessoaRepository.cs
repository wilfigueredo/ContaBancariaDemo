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
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ContaContext context) : base(context)
        {
        }

        public Pessoa ObterPorCpf(string cpf)
        {
            return Buscar(p => p.CPF == cpf).FirstOrDefault();
        }

        public IEnumerable<Pessoa> ObterPorNome(string nome)
        {
            return Buscar(p => p.Nome.Contains(nome));
        }       
    }
}
