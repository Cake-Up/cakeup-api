using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class IngredienteConfiguration : IEntityTypeConfiguration<IngredienteEntity>
{
    public void Configure(EntityTypeBuilder<IngredienteEntity> builder)
    {
        builder.ToTable("ingrediente");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired();
        builder.Property(c => c.DataCriacao).IsRequired();
        builder.Property(c => c.CustoUnitario).IsRequired().HasPrecision(5,2);
        builder.Property(c => c.QtdPorEmbalagem).IsRequired();

        builder.HasMany(c => c.MovimentacoesIngredientes)
            .WithOne(c => c.Ingrediente)
            .HasForeignKey(c => c.IdIngrediente);

        builder.HasMany(r => r.ReceitasIngredientes)
            .WithOne(r => r.Ingrediente)
            .HasForeignKey(r => r.IdIngrediente);
    }
}
