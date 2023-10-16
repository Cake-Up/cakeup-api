using CakeUpERP.Application.Enums;
using CakeUpERP.Application.Helpers;
using CakeUpERP.Application.Interfaces;
using CakeUpERP.Application.Service;
using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Moq;
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

        [Fact(DisplayName = "Verificar se o sistema cria um token JWT valido")]
        public void TokenJWTComAssinaturaValidaETodaAsClaims_VerificarSeSistemaCriaUmTokenValido_ResultadoSucesso()
        {
            string senha = "12345678";
            UsuarioEntity usuario = new UsuarioEntity()
            {
                Ativo = true,
                DataExpiracaoRefreshToken = DateTime.Now.AddMinutes(-1),
                Email = "contato@email.com.br",
                Password = PasswordHelper.CriandoHashDaSenha(senha),
                Nome = "Joao da Silva Santos",
                Id = Guid.NewGuid().ToString(),
                RefreshToken = Guid.NewGuid().ToString(),
                Role = (int)RolesUsuarios.Suporte,
                IdCompanhia = 1,
                Companhia = new CompanhiaEntity()
                {
                    Id = 1,
                    Cnpj = "123456789101112",
                    DataCriacao = new DateTime(2023,9,01),
                    Clientes = new List<ClienteEntity>(),
                    Usuarios = new List<UsuarioEntity>(),
                    Nome = "Cake Up ERP",
                    NomeSite = "cake-up-erp",
                    UrlImagem = "url-qweqweqwe.jpg"
                }
            };

            var myConfiguration = new Dictionary<string, string>
                {
                    {"JWT:Secret", "9cfc+66c4#-dc9$9-4fd+a+%-b777-2c8!b7-591&*/c349"},
                    {"JWT:ValidadeRefreshTokenEmMinutos", "60"},
                };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var usuarioRepository = new Mock<IUsuarioRepository>();
            var tokenService = new TokenService(configuration);
            var company = new Mock<ICompanhiaRepository>();

            var usuarioService = new UsuarioService(usuarioRepository.Object,tokenService, company.Object);

            usuarioRepository.Setup(u => u.ObterUsuarioPorEmail(It.IsNotNull<string>())).Returns(Task.FromResult(usuario));

            var token = usuarioService.Login("contato@email.com.br", senha).Result;

            Assert.True(!string.IsNullOrEmpty(token.AcessToken));
        }
    }
}
