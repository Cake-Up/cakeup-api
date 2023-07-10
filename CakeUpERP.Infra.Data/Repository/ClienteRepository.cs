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

        public Task<ObservacaoClienteEntity?> ObterObservacaoCliente(int idObservacao)
        {
            return context.observacoesCliente.Where(c => c.Id == idObservacao).FirstOrDefaultAsync();
        }

        public Task DeletarCliente(int idCliente)
        {
            var cliente = ObterPorID(idCliente).Result;
            cliente.DataExclusao = DateTime.Now;
            DeletarObservacaoCliente(idCliente);
            return context.SaveChangesAsync();
        }

        public Task DeletarTodasObservacaosCliente(int idCliente)
        {
            var cliente = ObterPorID(idCliente).Result;

            if(cliente == null)
                return Task.CompletedTask;

            var observacoes = cliente!.ObservacaoClienteEntities;
            var deletarObservacaos = new List<Task>();
            observacoes.ForEach(c => deletarObservacaos.Add(DeletarObservacaoCliente(c.Id)));
            return Task.WhenAll(deletarObservacaos.ToArray());
        }

        public Task DeletarObservacaoCliente(int idObservacao)
        {
            var observacaoCliente = context.observacoesCliente.Find(idObservacao);
            observacaoCliente.DataExclusao = DateTime.Now;
            return context.SaveChangesAsync();
        }


        public Task AdicionarObservacaoCliente(ObservacaoClienteEntity observacao)
        {
            if(observacao.IdCliente == 0)
                throw new NullReferenceException(nameof(observacao));

            context.observacoesCliente.Add(observacao);
            return context.SaveChangesAsync();
        }

        public Task<List<ObservacaoClienteEntity>> ObterObservacoesClientePagination(FiltroBuscaObservacaoCliente filtro)
        {
            return context.observacoesCliente.Where(c => c.IdCliente == filtro.IdCliente && c.DataExclusao == null)
                .Skip(filtro.Skip)
                .Take(filtro.QtdRegistros)
                .ToListAsync();
        }

        public bool VerificarClienteCompanhia(int idCliente, int idCompanhia)
        {
            if(idCliente == 0 || idCompanhia == 0)
                return false;

            return dbSet.Find(idCliente)?.IdCompanhia == idCompanhia;
        }
    }
}
