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
    public class RlUtensiliosReceitaConfiguration : IEntityTypeConfiguration<RlUtensiliosReceita>
    {
        public void Configure(EntityTypeBuilder<RlUtensiliosReceita> builder)
        {
            builder.ToTable("rlUtensiliosReceita");
            builder.HasKey(c => c.Id);

            builder.HasOne(k => k.Receita)
                .WithMany(k => k.UtensiliosEEquipamentos)
                .HasForeignKey(k => k.IdReceita);

            builder.HasOne(k => k.Utensilios)
                .WithMany(k => k.ReceitasUtensilios)
                .HasForeignKey(k => k.IdUtensilio);

        }
    }
}
