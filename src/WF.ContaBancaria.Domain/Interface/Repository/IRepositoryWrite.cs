using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Interface.Repository
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : class
    {
        // Repositorio para escrita do branco
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid Id);
        int SaveChanges();

    }
}
