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
    public class UtensiliosEEquipamentosConfiguration : IEntityTypeConfiguration<UtensiliosEEquipamentosEntity>
    {
        public void Configure(EntityTypeBuilder<UtensiliosEEquipamentosEntity> builder)
        {
            builder.ToTable("utensiliosEEquipamentos");
            builder.HasKey(c => c.Id);
        }
    }
}
