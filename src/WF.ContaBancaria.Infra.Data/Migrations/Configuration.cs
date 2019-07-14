namespace WF.ContaBancaria.Infra.Data.Migrations
{
    using WF.ContaBancaria.Domain.Models;
    using WF.ContaBancaria.Infra.Data.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ContaContext context)
        {
           
            IList<Cliente> Clientes = new List<Cliente>();
            DateTime DataNasc = new DateTime(1988, 6, 1);
            Clientes.Add(new Cliente { Nome = "William", CPF = "12345678911", DataNascimento = DataNasc });

            foreach(var Cliente in Clientes)
            { 
                context.Clientes.AddOrUpdate(p => p.Id, Cliente);
            }
            context.SaveChanges();
        }
    }
}
