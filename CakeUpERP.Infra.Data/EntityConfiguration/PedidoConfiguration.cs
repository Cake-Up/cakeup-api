using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Infra.Data.EntityConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable("pedido");
            builder.HasKey(c => c.Id);

            builder.HasOne(k => k.Cliente)
                .WithMany(k => k.PedidosCliente)
                .HasForeignKey(k => k.IdCliente);

            builder.HasOne(k => k.Orcamento)
                .WithOne(k => k.Pedido)
                .HasForeignKey<PedidoEntity>(k => k.IdOrcamento);
        }
    }
}
