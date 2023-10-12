using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
{
    public void Configure(EntityTypeBuilder<ClienteEntity> builder)
    {
        builder.ToTable("cliente");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Apelido).IsRequired();
        builder.Property(c => c.Nome).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();

        builder.HasOne(c => c.Companhia)
            .WithMany(c => c.Clientes)
            .HasForeignKey(c => c.IdCompanhia);
    }
}
