using CakeUpERP.Application.DTO.Companhia;
using CakeUpERP.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace CakeUpERP.Application.DTO.Usuario;
public class UsuarioDTO
{
    public string IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IdRole { get; set; }
    public string Role { get => ((Enums.RolesUsuarios)IdRole).Description(); }
    public CompanhiaDTO Companhia { get; set; }
}
