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

        public Task CadastrarCliente(DadosCliente cliente)
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

        public Task AtualizarCliente(DadosCliente cliente)
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

        public Task CadastrarObservacaoCliente(DadosObservacaoCliente observacao)
        {
            try
            {
                var observacaoClienteEntity = new ObservacaoClienteEntity()
                {
                    Observacao = observacao.Observacao,
                    IdCliente = observacao.IdCliente,
                    DataObservacao = observacao.DataObservacao
                };

                return _repository.AdicionarObservacaoCliente(observacaoClienteEntity);

            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public List<DadosObservacaoCliente> ObterObservacoesCliente(FiltroBuscaObservacaoCliente filtro)
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

        public List<ClienteDTO> ObterTodosOsClientes(int idCompanhia)
        {
            try
            {
                return _repository.ObterTodosOsClientes(idCompanhia)
                    .Result
                    .Select(k => new ClienteDTO(k))
                    .ToList();
            }
            catch(Exception e)
            {
                return new List<ClienteDTO>();
            }

        }

        public Task DeletarCliente(int idCliente)
        {
            try
            {
                return _repository.DeletarCliente(idCliente);
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task DeletarObservacaoCliente(int idObservacao)
        {
            try
            {
                return _repository.DeletarObservacaoCliente(idObservacao);
            }
            catch(Exception e) { return Task.FromException(e); }
        }

        public ClienteDTO ObterCliente(int idCliente)
        {
            try
            {
                return new ClienteDTO(_repository.ObterPorID(idCliente).Result);
            }
            catch (Exception e) { throw e;}
        }

        public bool VerificarClienteCompanhia(int idCliente, int idCompanhia)
        {
            return _repository.VerificarClienteCompanhia(idCliente, idCompanhia);
        }
    }
}
