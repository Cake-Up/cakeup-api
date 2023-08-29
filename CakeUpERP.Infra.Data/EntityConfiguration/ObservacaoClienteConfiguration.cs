using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class ObservacaoClienteConfiguration : IEntityTypeConfiguration<ObservacaoClienteEntity>
{
    public void Configure(EntityTypeBuilder<ObservacaoClienteEntity> builder)
    {
        builder.ToTable("observacao_cliente");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Observacao).HasMaxLength(256);
        builder.Property(c => c.DataCriacao).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .HasOne(o => o.Cliente)
            .WithMany(e => e.ObservacaoClienteEntities)
            .HasForeignKey(e => e.IdCliente);
    }
}
