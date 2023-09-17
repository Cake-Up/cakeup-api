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
    public class ReceitaConfigration : IEntityTypeConfiguration<ReceitaEntity>
    {
        public void Configure(EntityTypeBuilder<ReceitaEntity> builder)
        {
            builder.ToTable("receita");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(60);
            builder.Property(c => c.DataCriacao).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.CustoReceita).IsRequired().HasPrecision(5, 2);
            builder.Property(c => c.Peso).IsRequired();
            builder.Property(c => c.EndereçoImagem).HasMaxLength(256);

            builder.HasMany(r => r.Ingrediente)
                .WithOne(r => r.Receita)
                .HasForeignKey(r => r.IdReceita);

            builder.HasMany(r => r.UtensiliosEEquipamentos)
                .WithOne(r => r.Receita)
                .HasForeignKey(r => r.IdReceita);

        }
    }
}
