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

        [HttpPost]
        public IActionResult Cadastrar(DadosCliente cliente)
        {
            var cadastroCliente = _clienteService.CadastrarCliente(cliente);
            if(cadastroCliente.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Cliente Cadastrado com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel cadastrar o cliente" });
        }

        [HttpPost]
        public IActionResult AdicionarObservacaoCliente(DadosObservacaoCliente dadosObservacaoCliente)
        {
            var resultado = _clienteService.CadastrarObservacaoCliente(dadosObservacaoCliente);
            if (resultado.IsCompletedSuccessfully)
                return Ok(new { mensagem = "Observacao Cadastrada com sucesso" });

            return BadRequest(new { mensagem = "Não foi possivel cadastrar o observacao" });
        }
    }
}
