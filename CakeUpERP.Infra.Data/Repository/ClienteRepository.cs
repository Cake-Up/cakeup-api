using CakeUpERP.Domain.Cliente;
using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CakeUpERP.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(DataContext DbContext) : base(DbContext) { }

        public Task<List<ClienteEntity>> ObterTodosOsClientes(int idCompanhia)
        {
            return dbSet.Where(c => c.IdCompanhia == idCompanhia && c.DataExclusao == null).ToListAsync();
        }

        public Task<List<ObservacaoClienteEntity>> ObterObservacoesClientePagination(FiltroBuscaComentariosCliente filtro)
        {
            return context.observacoesCliente.Where(c => c.IdCliente == filtro.IdCliente)
                .Skip(filtro.Skip)
                .Take(filtro.QtdRegistros)
                .ToListAsync();
        }
    }
}
