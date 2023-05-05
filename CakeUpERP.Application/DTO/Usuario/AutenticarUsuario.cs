using System.ComponentModel.DataAnnotations;

namespace CakeUpERP.Application.DTO.Usuario;
public class AutenticarUsuario
{
    private string _email
    { 
        get; 
        set; 
    }

    [Required]
    [MaxLength(256,ErrorMessage = "O Email deve ter no maximo 256 caracteres")]
    [MinLength(10, ErrorMessage = "O Email deve ter no minimo 10 caracteres")]
    public string Email 
    { 
        get => _email.Trim().ToLower(); 
        set => _email = value; 
    }
    [Required]
    [MaxLength(128, ErrorMessage = "O Email deve ter no maximo 128 caracteres")]
    [MinLength(8, ErrorMessage = "O Email deve ter no minimo 8 caracteres")]
    public string Password { get; set; }

}