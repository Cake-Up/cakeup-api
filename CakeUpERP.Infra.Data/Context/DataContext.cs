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
        public DbSet<ClienteEntity> cliente => Set<ClienteEntity>();
        public DbSet<ObservacaoClienteEntity> observacoesCliente => Set<ObservacaoClienteEntity>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new CompanhiaConfiguration());
            builder.ApplyConfiguration(new ClienteConfiguration());
            builder.ApplyConfiguration(new ObservacaoClienteConfiguration());

        }
    }
}
