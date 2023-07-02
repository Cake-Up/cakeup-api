using CakeUpERP.Domain.Cliente;
using CakeUpERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Interfaces.Repositorys
{
    public interface IClienteRepository : IRepositoryBase<ClienteEntity>
    {
        Task AdicionarObservacaoCliente(ObservacaoClienteEntity observacao);
        Task DeletarCliente(int idCliente);
        Task DeletarObservacaoCliente(int idObservacao);
        Task DeletarTodasObservacaosCliente(int idCliente);
        Task<ObservacaoClienteEntity?> ObterObservacaoCliente(int idObservacao);
        Task<List<ObservacaoClienteEntity>> ObterObservacoesClientePagination(FiltroBuscaObservacaoCliente filtro);
        Task<List<ClienteEntity>> ObterTodosOsClientes(int idCompanhia);

    }
}
