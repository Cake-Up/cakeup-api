using CakeUpERP.Application.DTO.Cliente;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Domain.Cliente;
using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;

namespace CakeUpERP.Application.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        { 
            _repository = repository;
        }

        public Task Cadastrar(DadosCliente cliente)
        {
            try
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
                return _repository.Cadastrar(clienteEntity);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task Atualizar(DadosCliente cliente)
        {
            try
            {
                var clienteEntity = new ClienteEntity()
                {
                    Email = cliente.Email,
                    Apelido = cliente.Apelido,
                    Genero = cliente.Genero,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone,
                    IdCompanhia = cliente.IdCompanhia,
                    Endereco = cliente.Endereco,
                    DataUpdate = DateTime.Now
                };
                return _repository.Atualizar(clienteEntity);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task CadastrarObservacao(DadosObservacaoCliente observacao)
        {
            try
            {
                var observacaoClienteEntity = new ObservacaoClienteEntity()
                {
                    Observacao = observacao.Observacao,
                    IdCliente = observacao.IdCliente,
                    DataObservacao = observacao.DataObservacao
                };

                return _repository.AdicionarObservacao(observacaoClienteEntity);

            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public List<DadosObservacaoCliente> ObterObservacoes(FiltroBuscaObservacaoCliente filtro)
        {
            try
            {
                return _repository.ObterObservacoesClientePagination(filtro).Result
                    .Select(k => new DadosObservacaoCliente(k))
                    .ToList();
            }
            catch(Exception e)
            {
                return new List<DadosObservacaoCliente>();
            }

        }

        public List<ClienteDTO> ObterTodos(int idCompanhia)
        {
            try
            {
                return _repository.ObterTodos(idCompanhia)
                    .Result
                    .Select(k => new ClienteDTO(k))
                    .ToList();
            }
            catch(Exception e)
            {
                return new List<ClienteDTO>();
            }

        }

        public Task Deletar(int idCliente)
        {
            try
            {
                return _repository.Deletar(idCliente);
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task DeletarObservacao(int idObservacao)
        {
            try
            {
                return _repository.DeletarObservacao(idObservacao);
            }
            catch(Exception e)
            { 
                return Task.FromException(e);
            }
        }

        public ClienteDTO? ObterPorId(int idCliente)
        {
            try
            {
                var cliente = _repository.ObterPorID(idCliente).Result;
                return new ClienteDTO(cliente);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool VerificarClienteCompanhia(int idCliente, int idCompanhia)
        {
            return _repository.VerificarClienteCompanhia(idCliente, idCompanhia);
        }
    }
}
