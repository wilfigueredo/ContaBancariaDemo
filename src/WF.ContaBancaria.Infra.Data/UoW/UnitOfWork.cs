using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.ContaBancaria.Infra.Data.Context;

namespace WF.ContaBancaria.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContaContext _context;

        public UnitOfWork(ContaContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
