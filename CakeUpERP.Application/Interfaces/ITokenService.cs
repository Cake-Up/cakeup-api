using CakeUpERP.Application.DTO.Token;
using CakeUpERP.Application.DTO.Usuario;
using System.Security.Claims;

namespace CakeUpERP.Application.Interfaces;
public interface ITokenService
{
    TokenModel AuthenticarAtravesDoRefreshToken(TokenModel token);
    string GerarRefreshToken();
    public string GerarToken(UsuarioDTO usuario);
    public string GerarToken(IEnumerable<Claim> claims);
    IEnumerable<Claim> ObterClaimsDeTokenExpirado(string? token);
    DateTime ObterDataExpiracaoRefreshToken();
}
