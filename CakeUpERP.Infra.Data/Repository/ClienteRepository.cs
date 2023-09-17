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

        public Task<List<ClienteEntity>> ObterTodos(int idCompanhia)
        {
            return dbSet.Where(c => c.IdCompanhia == idCompanhia && c.DataExclusao == null).ToListAsync();
        }

        public Task<ObservacaoClienteEntity?> ObterObservacaoCliente(int idObservacao)
        {
            return context.ObservacoesCliente.Where(c => c.Id == idObservacao).FirstOrDefaultAsync();
        }

        public Task Deletar(int idCliente)
        {
            var cliente = ObterPorID(idCliente).Result;
            cliente.DataExclusao = DateTime.Now;
            DeletarObservacao(idCliente);
            return context.SaveChangesAsync();
        }

        public Task DeletarTodasObservacaosCliente(int idCliente)
        {
            var cliente = ObterPorID(idCliente).Result;

            if(cliente == null)
                return Task.CompletedTask;

            var observacoes = cliente!.ObservacaoClienteEntities;
            var deletarObservacaos = new List<Task>();
            observacoes.ForEach(c => deletarObservacaos.Add(DeletarObservacao(c.Id)));
            return Task.WhenAll(deletarObservacaos.ToArray());
        }

        public Task DeletarObservacao(int idObservacao)
        {
            var observacaoCliente = context.ObservacoesCliente.Find(idObservacao);
            observacaoCliente.DataExclusao = DateTime.Now;
            return context.SaveChangesAsync();
        }


        public Task AdicionarObservacao(ObservacaoClienteEntity observacao)
        {
            if(observacao.IdCliente == 0)
                throw new NullReferenceException(nameof(observacao));

            context.ObservacoesCliente.Add(observacao);
            return context.SaveChangesAsync();
        }

        public Task<List<ObservacaoClienteEntity>> ObterObservacoesClientePagination(FiltroBuscaObservacaoCliente filtro)
        {
            return context.ObservacoesCliente.Where(c => c.IdCliente == filtro.IdCliente && c.DataExclusao == null)
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
