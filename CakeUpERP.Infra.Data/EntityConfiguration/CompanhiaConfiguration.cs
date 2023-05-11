using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class CompanhiaConfiguration : IEntityTypeConfiguration<CompanhiaEntity>
{
    public void Configure(EntityTypeBuilder<CompanhiaEntity> builder)
    {
        builder.ToTable("companhia");
        builder.HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.Cnpj);
        builder.Property(u => u.Nome).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Cnpj).HasMaxLength(14);
        builder.Property(u => u.NomeSite).HasMaxLength(80);

        builder.HasData(
            new CompanhiaEntity()
            {
                Id = 1,
                Cnpj = "64547425000106",
                DataCriacao = DateTime.Now,
                Nome = "Companhia 01 Ltda",
                UrlImagem = ""
            });
    }
}
