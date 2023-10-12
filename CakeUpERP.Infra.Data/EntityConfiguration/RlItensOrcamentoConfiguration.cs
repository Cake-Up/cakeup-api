using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class RlItensOrcamentoConfiguration : IEntityTypeConfiguration<RlItensOrcamento>
{
    public void Configure(EntityTypeBuilder<RlItensOrcamento> builder)
    {
        builder.ToTable("itensOrcamento");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.IdStatus).IsRequired();

        builder.HasOne(k => k.Ingrediente)
            .WithMany(k => k.RlItensOrcamentos)
            .HasForeignKey(k => k.IdIngrediente);

        builder.HasOne(k => k.Receita)
            .WithMany(k => k.RlItensOrcamentos)
            .HasForeignKey(k => k.IdReceita);

    }
}
