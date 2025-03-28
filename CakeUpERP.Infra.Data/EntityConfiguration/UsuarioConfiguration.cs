﻿using CakeUpERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CakeUpERP.Infra.Data.EntityConfiguration;
public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("usuario");
        builder.HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.Email);
        builder.Property(u => u.Id).HasMaxLength(36);
        builder.Property(u => u.Nome).HasMaxLength(50).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Password).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Role).HasMaxLength(32);
        builder.Property(u => u.Ativo).HasDefaultValue(true);
        builder.Property(u => u.Cpf).HasMaxLength(11);
        builder.Property(u => u.IdCompanhia).IsRequired();

        builder.HasOne(u => u.Companhia)
            .WithMany(c => c.Usuarios)
            .HasForeignKey(u => u.IdCompanhia);
    }
}
