using WF.ContaBancaria.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.Interface
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel Cliente);
        ClienteViewModel ObterPorId(Guid Id);        
        IEnumerable<ClienteViewModel> ObterTodos();
        IEnumerable<ClienteViewModel> ObterPorCpf(string cpf);
        IEnumerable<ClienteViewModel> ObterPorNome(string nome);
        ClienteViewModel Atualizar(ClienteViewModel Cliente);
        void Remover(Guid id);
    }
}
