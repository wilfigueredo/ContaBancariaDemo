
using WF.ContaBancaria.Application.Interface;
using WF.ContaBancaria.Application.Services;
using WF.ContaBancaria.Domain.Interface.Repository;
using WF.ContaBancaria.Domain.Interface.Service;
using WF.ContaBancaria.Domain.Services;
using WF.ContaBancaria.Infra.Data.Context;
using WF.ContaBancaria.Infra.Data.Repository;
using WF.ContaBancaria.Infra.Data.UoW;
using SimpleInjector;

namespace WF.ContaBancaria.infra.CrossCuting.IoC
{
    public class SimpleInjectorBootstrapper
    {
        public static void Register(Container container)
        {
            //APP
            container.Register<IContaAppService,ContaAppService>(Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService,ClienteService>(Lifestyle.Scoped);
            container.Register<IContaService, ContaService>(Lifestyle.Scoped);
            container.Register<ITransacaoService, TransacoesService>(Lifestyle.Scoped);

            //Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ITransacoesRepository, TransacoesRepository>(Lifestyle.Scoped);
            container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ContaContext>(Lifestyle.Scoped);
        }
    }
}
