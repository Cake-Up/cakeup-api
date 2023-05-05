using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeUpERP.Domain.Entities;

public class UsuarioEntity
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public int IdCompanhia { get; set; }
    public bool Ativo { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataExclusao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime? DataExpiracaoRefreshToken { get; set; }
    public CompanhiaEntity Companhia { get; set; }
    public bool RefreshTokenExpirado()
    {
        if (DataExpiracaoRefreshToken == null)
            return false;

        return DataExpiracaoRefreshToken <= DateTime.Now;
    }
}