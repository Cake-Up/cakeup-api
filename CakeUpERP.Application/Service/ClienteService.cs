using CakeUpERP.Application.DTO.Cliente;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Application.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        { 
            _repository = repository;
        }

        public Task CadastrarCliente(CadastrarClienteModel cliente)
        {
            var clienteEntity = new ClienteEntity()
            {
                Email = cliente.Email,
                Apelido = cliente.Apelido,
                Genero = cliente.Genero,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                IdCompanhia = cliente.IdCompanhia,
                Endereco = cliente.Endereco
            };
            try
            {
                return _repository.Cadastrar(clienteEntity);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
