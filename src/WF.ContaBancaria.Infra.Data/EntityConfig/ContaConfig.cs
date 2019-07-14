using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Infra.Data.EntityConfig
{
    public class ContaConfig : EntityTypeConfiguration<Conta>
    {
        public ContaConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Saldo)
                .IsRequired();

            Property(c => c.LimiteSaqueDiario)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();                        

            Property(c => c.TipoConta)
                .IsRequired();

            // Mapeamento relacionamento 0 or 1 To 0 or 1 
            HasOptional(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

            Ignore(c => c.ValidationResult);

            ToTable("Contas");
        }
    }
}
