using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CakeUpERP.Infra.Data.Repository;
public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly DataContext context;
    protected readonly DbSet<TEntity> dbSet;

    public RepositoryBase(DataContext dbContext)
    {
        context = dbContext;
        dbSet = dbContext.Set<TEntity>();
    }

    public virtual async Task Cadastrar(TEntity entity)
    {
        dbSet.Add(entity);
        context.SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
    }

    public virtual async Task<TEntity?> ObterPorID(int id)
    {
        return dbSet.Find(id);
    }
}
