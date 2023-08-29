using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CakeUpERP.Infra.Data.Repository
{
    public class UsuarioRepository: RepositoryBase<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext DbContext):base(DbContext) { }

        public async Task<UsuarioEntity?> ObterUsuarioPorEmail(string email)
        {
            var usuario = dbSet.Where(u => u.Ativo)
                .Include(u => u.Companhia)
                .FirstOrDefault(u => u.Email == email);

            return usuario;
        }

        public Task<List<UsuarioEntity?>> ObterUsuariosDaCompanhia(int idCompanhia)
        {
            var listaUsuario = dbSet.Where(u => u.IdCompanhia == idCompanhia).ToList();
            return Task.FromResult(listaUsuario);
        }

        public Task RevogarAcessoUsuario(string email)
        {
            try
            {
                var usuario = dbSet.Where(u => u.Email == email).FirstOrDefault();
                usuario.Ativo = false;
                context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
