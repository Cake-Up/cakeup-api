using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Infra.Data.EntityConfiguration
{
    public class OrcamentoConfiguration : IEntityTypeConfiguration<OrcamentoEntity>
    {
        public void Configure(EntityTypeBuilder<OrcamentoEntity> builder)
        {
            builder.ToTable("Orcamento");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataOrcamento);
            builder.HasIndex(c => c.CodReferencia).IsUnique();

            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.OrcamentosCliente)
                .HasForeignKey(c => c.IdCliente);
        }
    }
}
