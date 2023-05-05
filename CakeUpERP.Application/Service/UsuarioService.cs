using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.DTO.Usuario;
using AutoMapper;
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
    private readonly IMapper _mapper;


    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, ITokenService tokenService, ICompanhiaRepository companhiaRepository)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _tokenService = tokenService;
        _companhiaRepository = companhiaRepository;
    }

    public async Task CadastrarUsuario(CriarUsuarioDTO newUser)
    {
        try
        {
            var dadosUsuario = await _usuarioRepository.ObterUsuarioPorEmail(newUser.Email);
            if (dadosUsuario != null)
                ObjetoCadastradoException.When("Email ja cadastrado no sistema");
            dadosUsuario = _mapper.Map<UsuarioEntity>(newUser);
            dadosUsuario.DataCriacao = DateTime.Now;
            dadosUsuario.Id = Guid.NewGuid().ToString();
            dadosUsuario.Companhia = _companhiaRepository.ObterPorID(newUser.IdCompanhia).Result;
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
            var user = _usuarioRepository.ObterUsuarioPorEmail(email).Result;

            if (user == null || !PasswordHelper.VerificandoSenha(user.Password, password))
                throw new Exception();

            token.AcessToken = _tokenService.GerarToken(_mapper.Map<UsuarioDTO>(user));
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