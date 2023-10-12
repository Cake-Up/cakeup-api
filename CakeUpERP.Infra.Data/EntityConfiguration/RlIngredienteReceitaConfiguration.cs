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
    public class RlIngredienteReceitaConfiguration : IEntityTypeConfiguration<RlIngredientesReceita>
    {
        public void Configure(EntityTypeBuilder<RlIngredientesReceita> builder)
        {
            builder.ToTable("rlIngredientesReceita");
            builder.HasKey(c => c.Id);

        }
    }
}
