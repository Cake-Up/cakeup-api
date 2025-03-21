﻿using CakeUpERP.Application.DTO;
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
        Task Atualizar(DadosCliente cliente);
        Task Cadastrar(DadosCliente cliente);
        Task CadastrarObservacao(DadosObservacaoCliente observacao);
        Task Deletar(int idCliente);
        Task DeletarObservacao(int idObservacao);
        List<DadosObservacaoCliente> ObterObservacoes(FiltroBuscaObservacaoCliente filtro);
        DadosCliente? ObterPorId(int idCliente);
        List<ClienteDTO> ObterTodos(int idCompanhia);
        bool VerificarClienteCompanhia(int idCliente, int idCompanhia);
    }
}
