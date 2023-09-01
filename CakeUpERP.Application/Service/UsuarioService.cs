using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.DTO.Usuario;
using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Validations;
using CakeUpERP.Application.Helpers;
using CakeUpERP.Application.DTO.Token;
using System.Security.Claims;

namespace CakeUpERP.Application.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ICompanhiaRepository _companhiaRepository;
    private readonly ITokenService _tokenService;


    public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService, ICompanhiaRepository companhiaRepository)
    {
        _usuarioRepository = usuarioRepository;
        _tokenService = tokenService;
        _companhiaRepository = companhiaRepository;
    }

    public async Task CadastrarUsuario(CriarUsuarioDTO novoUsuario)
    {
        try
        {
            var dadosUsuario = await _usuarioRepository.ObterUsuarioPorEmail(novoUsuario.Email);
            if (dadosUsuario != null)
                ObjetoCadastradoException.When("Email ja cadastrado no sistema");

            dadosUsuario = new UsuarioEntity()
            {
                Ativo = true,
                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Password = novoUsuario.Password,                
            };
            
            dadosUsuario.DataCriacao = DateTime.Now;
            dadosUsuario.Id = Guid.NewGuid().ToString();
            await _usuarioRepository.Cadastrar(dadosUsuario);
        }
        catch(Exception e)
        {
            throw e;
        }
    }

    public Task<TokenModel> Login(string email, string password)
    {
        try
        {
            var token = new TokenModel();
            var usuario = _usuarioRepository.ObterUsuarioPorEmail(email).Result;

            if (usuario == null || !PasswordHelper.VerificandoSenha(usuario.Password, password))
                throw new Exception();
            var userDTO = new UsuarioDTO()
            {
                Nome = usuario.Nome,
                Email = email,
                Password = password,
                IdUsuario = usuario.Id,
                Companhia = new DTO.Companhia.CompanhiaDTO()
                {
                    CNPJ = usuario.Companhia.Cnpj,
                    Id = usuario.Companhia.Id,
                    Nome = usuario.Companhia.Nome
                }
            };
            token.AcessToken = _tokenService.GerarToken(userDTO));
            token.RefreshToken = ObterRefreshToken(email);
            return Task.FromResult(token);
        }
        catch (Exception e)
        { 
            throw e; 
        }
    }

    public Task<UsuarioDTO?> BuscarPorEmail(string email)
    {
        UsuarioEntity? user = _usuarioRepository.ObterUsuarioPorEmail(email).Result;

        return Task.FromResult(_mapper.Map<UsuarioDTO?>(user));
    }

    public Task<List<UsuarioDTO?>> ObterTodosOsUsuarioDaCompanhia(int IdCompanhia)
    {
        List<UsuarioEntity?> user = _usuarioRepository.ObterUsuariosDaCompanhia(IdCompanhia).Result;

        return Task.FromResult(_mapper.Map<List<UsuarioDTO?>>(user));
    }

    public Task AtualizarUsuario(AtualizarUsuarioDTO dadosDoUsuario)
    {
        try
        {
            _usuarioRepository.Atualizar(_mapper.Map<UsuarioEntity>(dadosDoUsuario));
            return Task.CompletedTask;
        }
        catch(Exception e)
        {
            return Task.FromException(e);
        }
    }

    public Task RevogarAcessoUsuario(string email)
    {
        return _usuarioRepository.RevogarAcessoUsuario(email);
    }

    public Task<TokenModel> RenovarTokens(TokenModel token)
    {
        var claimsToken = _tokenService.ObterClaimsDeTokenExpirado(token.AcessToken);
        var emailUsuario = claimsToken.FirstOrDefault(a => a.Type == ClaimTypes.Email).Value;
        var usuario = _usuarioRepository.ObterUsuarioPorEmail(emailUsuario).Result;

        if (usuario.RefreshToken != token.RefreshToken || usuario.RefreshTokenExpirado())
            return Task.FromException<TokenModel>(new Exception("Token invalido ou expirado!"));

        var tokenModel = _tokenService.AuthenticarAtravesDoRefreshToken(token);

        AtualizarRefreshTokenUsuario(emailUsuario, tokenModel.RefreshToken);
        return Task.FromResult(tokenModel);
    }

    private string ObterRefreshToken(string email)
    {
        var refreshToken = _tokenService.GerarRefreshToken();
        AtualizarRefreshTokenUsuario(email, refreshToken);
        return refreshToken;
    }

    private void AtualizarRefreshTokenUsuario(string email, string refreshToken)
    {
        try
        {
            var usuario = _usuarioRepository.ObterUsuarioPorEmail(email).Result;
            usuario.RefreshToken = refreshToken;
            usuario.DataExpiracaoRefreshToken = _tokenService.ObterDataExpiracaoRefreshToken();
            _usuarioRepository.Atualizar(usuario);
        }
        catch(Exception ex)
        {

        }
    }
}