using CakeUpERP.Application.DTO;
using CakeUpERP.Application.DTO.Bases;
using CakeUpERP.Application.DTO.Cliente;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CakeUpERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IClaimsAcessor _jwt;
        public ClienteController(IClienteService clienteService, IClaimsAcessor claimsAcessor)
        {
            _clienteService = clienteService;
            _jwt = claimsAcessor;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(DadosCliente cliente)
        {
            var cadastroCliente = _clienteService.Cadastrar(cliente);
            if (cadastroCliente.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Cliente Cadastrado com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel cadastrar o cliente" });
        }

        [HttpPost("AdicionarObservacao")]
        public IActionResult AdicionarObservacao(DadosObservacaoCliente dadosObservacaoCliente)
        {
            var resultado = _clienteService.CadastrarObservacao(dadosObservacaoCliente);
            if (resultado.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Observacao Cadastrada com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel cadastrar o observacao " });
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(DadosCliente cliente)
        {
            var cadastroCliente = _clienteService.Atualizar(cliente);
            if (cadastroCliente.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Cliente atualizado com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel atualizar o cliente" });
        }

        [HttpDelete("Deletar/{idCliente}")]
        public IActionResult Deletar(int idCliente)
        {
            var result = _clienteService.Deletar(idCliente);
            if (result.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Cliente deletado com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel deletar o cliente" });
        }

        [HttpDelete("DeletarObservacao/{idObservacao}")]
        [ProducesResponseType(typeof(DefaultResponse), (int)HttpStatusCode.OK)]
        public IActionResult DeletarObservacao(int idObservacao)
        {
            var result = _clienteService.DeletarObservacao(idObservacao);
            if (result.IsCompletedSuccessfully)
                return Ok(DefaultResponse.Response("Observação deletado com sucesso"));

            return BadRequest(DefaultResponse.Response("Não foi possivel deletar o observação cliente"));
        }

        [HttpGet("ObterTodosOsClientes/{idCompanhia}")]
        [ProducesResponseType(typeof(List<ClienteDTO>), (int)HttpStatusCode.OK)]
        public IActionResult ObterTodosOsClientes(int idCompanhia)
        {
            return Ok(_clienteService.ObterTodos(idCompanhia));
        }

        [HttpGet("{idCliente}")]
        [ProducesResponseType(typeof(DadosCliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DefaultResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetClientePorId(int idCliente)
        {
            var cliente = _clienteService.ObterPorId(idCliente);
            
            if (cliente == null)
                return BadRequest(DefaultResponse.Response("Cliente não encontrado"));
            
            if (cliente.IdCompanhia != _jwt.IdCompanhia)
                return BadRequest(DefaultResponse.Response("Cliente não encontrado"));

            return Ok(cliente);
        }
    }
}
