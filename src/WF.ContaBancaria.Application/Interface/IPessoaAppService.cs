using WF.ContaBancaria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.Interface
{
    public interface IPessoaAppService : IDisposable
    {
        PessoaViewModel Adicionar(PessoaViewModel pessoa);
        PessoaViewModel ObterPorId(Guid Id);        
        IEnumerable<PessoaViewModel> ObterTodos();
        IEnumerable<PessoaViewModel> ObterPorCpf(string cpf);
        IEnumerable<PessoaViewModel> ObterPorNome(string nome);
        PessoaViewModel Atualizar(PessoaViewModel pessoa);
        void Remover(Guid id);
    }
}
