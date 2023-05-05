using CakeUpERP.Domain.Entities;

namespace CakeUpERP.Domain.Interfaces.Repositorys;
public interface IUsuarioRepository : IRepositoryBase<UsuarioEntity>
{
    Task<UsuarioEntity?> ObterUsuarioPorEmail(string email);
    Task<List<UsuarioEntity?>> ObterUsuariosDaCompanhia(int IdCompanhia);
    Task RevogarAcessoUsuario(string email);
}