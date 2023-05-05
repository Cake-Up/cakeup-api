using CakeUpERP.Application.Enums;
using CakeUpERP.Domain.Entities;
using Xunit;

namespace CakeUpERP.Tests
{
    public class UsuarioUnitTest
    {
        [Fact(DisplayName = "Validar se Refresh Token esta expirado")]
        public void DataExpiracaoRefreshTokenMenorQueAgora_VerificarSeORefreshTokenEstaExpirado_ResultadoSucesso()
        {
            UsuarioEntity usuario = new UsuarioEntity()
            {
                Ativo = true,
                DataExpiracaoRefreshToken = DateTime.Now.AddMinutes(-1),
                Email = "contato@email.com.br",
                Password = "123456789",
                Nome = "Joao da Silva Santos",
                Id = Guid.NewGuid().ToString(),
                RefreshToken = Guid.NewGuid().ToString(),
                Role = (int)RolesUsuarios.Suporte,
                IdCompanhia = 1            
            };


            Assert.True(usuario.RefreshTokenExpirado());        
        }
    }
}
