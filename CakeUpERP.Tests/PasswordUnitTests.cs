using CakeUpERP.Application.Enums;
using CakeUpERP.Application.Helpers;
using CakeUpERP.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace CakeUpERP.Tests
{
    public class PasswordUnitTests
    {
        [Fact(DisplayName = "Validar se Senhas estão sendo criptografadas")]
        public void SenhasEmPlanTextDevemSerDiferentesDaCriptografada_VerificarSeSenhasEstaoSendoCriptogradas_ResultadoSucesso()
        {
            string senha = "12345678";
            string senhaCriptografada = PasswordHelper.CriandoHashDaSenha(senha);

            Assert.True(senha != senhaCriptografada);
        }

        [Fact(DisplayName = "Validar se validação se senhas criptografadas são iguais")]
        public void SenhaEnviadaDeveSerIgualACriptografada_VerificarSeSistemaConsegueVerificarSenha_ResultadoSucesso()
        {
            string senha = "12345678";
            string senhaCriptografada = PasswordHelper.CriandoHashDaSenha(senha);

            Assert.True(PasswordHelper.VerificandoSenha(senhaCriptografada, senha));
        }
    }
}
