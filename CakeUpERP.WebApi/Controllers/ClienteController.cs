using CakeUpERP.Application.DTO.Cliente;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeUpERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(DadosCliente cliente)
        {
            var cadastroCliente = _clienteService.Cadastrar(cliente);
            if(cadastroCliente.IsCompletedSuccessfully)
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
        public IActionResult DeletarObservacao(int idObservacao)
        {
            var result = _clienteService.DeletarObservacao(idObservacao);
            if (result.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Observação deletado com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel deletar o observação cliente" });
        }
    }
}
