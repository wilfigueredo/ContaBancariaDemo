using WF.ContaBancaria.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Application.Services
{
    public abstract class AppServices
    {

        private readonly IUnitOfWork _uow;

        public AppServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }

    }
}
