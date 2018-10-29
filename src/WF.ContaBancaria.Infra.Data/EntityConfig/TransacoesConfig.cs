using WF.ContaBancaria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Infra.Data.EntityConfig
{
    public class TransacoesConfig : EntityTypeConfiguration<Transacoes>
    {
        public TransacoesConfig()
        {
            HasKey( t => t.Id);

            Property(t => t.Valor)
                .IsRequired();

            // Mapeamento 0 To N
            HasRequired(t => t.Contas)
                .WithMany(p => p.Transacoes)
                .HasForeignKey(t => t.ContaId);

            ToTable("Transacoes");
        }
    }
}
