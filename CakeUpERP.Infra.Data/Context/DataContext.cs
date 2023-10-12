using CakeUpERP.Domain.Entities;
using CakeUpERP.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CakeUpERP.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<ClienteEntity> Cliente => Set<ClienteEntity>();
        public DbSet<CompanhiaEntity> Companhia => Set<CompanhiaEntity>();
        public DbSet<IngredienteEntity> Ingrediente => Set<IngredienteEntity>();
        public DbSet<MovimentacoesIngredientes> MovimentacoesIngredientes => Set<MovimentacoesIngredientes>();
        public DbSet<ObservacaoClienteEntity> ObservacoesCliente => Set<ObservacaoClienteEntity>();
        public DbSet<PedidoEntity> Pedido => Set<PedidoEntity>();
        public DbSet<ReceitaEntity> Receitas => Set<ReceitaEntity>();
        public DbSet<RlIngredientesReceita> RlIngredientesReceita => Set<RlIngredientesReceita>();
        public DbSet<RlItensOrcamento> RlItensOrcamento => Set<RlItensOrcamento>();
        public DbSet<RlUtensiliosReceita> RlUtensiliosReceita => Set<RlUtensiliosReceita>();
        public DbSet<OrcamentoEntity> Orcamento => Set<OrcamentoEntity>();
        public DbSet<UsuarioEntity> Usuario => Set<UsuarioEntity>();
        public DbSet<UtensiliosEEquipamentosEntity> UtensiliosEEquipamentos => Set<UtensiliosEEquipamentosEntity>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClienteConfiguration());
            builder.ApplyConfiguration(new CompanhiaConfiguration());
            builder.ApplyConfiguration(new IngredienteConfiguration());
            builder.ApplyConfiguration(new MovimentacoesIngredientesConfiguration());
            builder.ApplyConfiguration(new ObservacaoClienteConfiguration());
            builder.ApplyConfiguration(new OrcamentoConfiguration());
            builder.ApplyConfiguration(new PedidoConfiguration());
            builder.ApplyConfiguration(new ReceitaConfiguration());
            builder.ApplyConfiguration(new RlIngredienteReceitaConfiguration());
            builder.ApplyConfiguration(new RlItensOrcamentoConfiguration());
            builder.ApplyConfiguration(new RlUtensiliosReceitaConfiguration());
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new UtensiliosEEquipamentosConfiguration());


        }
    }
}
