using CakeUpERP.Domain.Entities;
using CakeUpERP.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CakeUpERP.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> usuario => Set<UsuarioEntity>();
        public DbSet<CompanhiaEntity> companhia => Set<CompanhiaEntity>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new CompanhiaConfiguration());

        }
    }
}
