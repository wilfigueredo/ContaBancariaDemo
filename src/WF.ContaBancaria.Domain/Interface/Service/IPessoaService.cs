using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Service
{
    public interface IPessoaService : IDisposable
    {
        Pessoa Adicionar(Pessoa pessoa);
        Pessoa Atualizar(Pessoa pessoa);
    }
}
