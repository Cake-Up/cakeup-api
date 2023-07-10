using CakeUpERP.Application.DTO.Cliente;
using CakeUpERP.Domain.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Interfaces
{
    public interface IClienteService
    {
        Task AtualizarCliente(DadosCliente cliente);
        Task CadastrarCliente(DadosCliente cliente);
        Task CadastrarObservacaoCliente(DadosObservacaoCliente observacao);
        Task DeletarCliente(int idCliente);
        Task DeletarObservacaoCliente(int idObservacao);
        List<DadosObservacaoCliente> ObterObservacoesCliente(FiltroBuscaObservacaoCliente filtro);
        List<ClienteDTO> ObterTodosOsClientes(int idCompanhia);
        ClienteDTO ObterCliente(int idCliente);
        bool VerificarClienteCompanhia(int idCliente, int idCompanhia);
    }
}
