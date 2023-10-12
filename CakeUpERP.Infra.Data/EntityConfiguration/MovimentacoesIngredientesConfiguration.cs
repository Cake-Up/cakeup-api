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
    public class MovimentacoesIngredientesConfiguration : IEntityTypeConfiguration<MovimentacoesIngredientes>
    {
        public void Configure(EntityTypeBuilder<MovimentacoesIngredientes> builder)
        {
            builder.ToTable("movimentacoesIngredientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataMovimentacao).IsRequired();

            builder.HasOne(k => k.Ingrediente)
                .WithMany(k => k.MovimentacoesIngredientes)
                .HasForeignKey(k => k.IdIngrediente);

            builder.HasOne(k => k.Receita)
                .WithMany(k => k.MovimentacoesIngredientes)
                .HasForeignKey(k => k.IdReceita);

        }
    }
}
