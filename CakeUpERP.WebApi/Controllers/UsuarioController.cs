using CakeUpERP.Application.DTO.Token;
using CakeUpERP.Application.DTO.Usuario;
using CakeUpERP.Application.Enums;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CakeUpERP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{

    private IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("Cadastrar")]
    [AllowAnonymous]
    public IActionResult CadastrarUsuario(CriarUsuarioDTO dadosUsuario)
    {
        try
        {
            dadosUsuario.Email = dadosUsuario.Email.ToLower().Trim();            
            var resultado = _usuarioService.CadastrarUsuario(dadosUsuario);
            if (resultado.IsFaulted)
                throw new Exception("Não foi possivel cadastrar o usuario!");

            return Ok(new { message = "Usuario cadastrado com sucesso!" });
        }
        catch(Exception e)
        {
            return BadRequest(new { message = e.Message });
        }

    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public IActionResult Autenticar([FromBody] AutenticarUsuario model)
    {
        try
        {
            model.Email = model.Email.ToLower().Trim();
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return NotFound(new { message = "Email ou senha não informados" });
            }

            TokenModel tokenModel = _usuarioService.Login(model.Email, model.Password).Result;
            return Ok(tokenModel);
        }
        catch
        {
            return BadRequest(new { message = "Email ou senha incorretos!" });
        }
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Administrador,Suporte,Funcionario")]
    public IActionResult AtualizarUsuario(AtualizarUsuarioDTO dadosUsuario)
    {
        throw new NotImplementedException();
    }

    [HttpPut("RevogarAcesso")]
    [Authorize(Roles = "Administrador,Suporte")]
    public IActionResult RevogarAcesso(string email)
    {
        var resultado = _usuarioService.RevogarAcessoUsuario(email);
        if(resultado.IsCompletedSuccessfully)
            return Ok(new { message = "Acesso do usuario revogado com sucesso!" });

        return BadRequest(new { message = "Não foi possivel revogar o acesso do usuario" });
    }

    [HttpGet("ObterUsuariosPorIdCompanhia/{IdCompanhia}")]
    [Authorize(Roles = "Administrador,Suporte")]
    public IActionResult ObterUsuariosPorIdCompanhia(int IdCompanhia)
    {
        var users = _usuarioService.ObterTodosOsUsuarioDaCompanhia(IdCompanhia).Result;
        if (!users.Any())
            return NoContent();

        return Ok(users);
    }

    private bool AtualizarDadosUsuario(UsuarioDTO usuario, AtualizarUsuarioDTO dadosUsuario)
    {
        throw new NotImplementedException();
    }

    [HttpPost("RenovarToken/")]
    [AllowAnonymous]
    public IActionResult RenovarToken(TokenModel token)
    {
        try
        {
            var tokenModel = _usuarioService.RenovarTokens(token).Result;
            if (tokenModel == null)
                throw new Exception();

            return Ok(tokenModel);
        }catch
        {
            return NoContent();
        }
    }
}