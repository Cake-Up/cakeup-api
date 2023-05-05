using CakeUpERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Interfaces.Repositorys;
public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task Cadastrar(TEntity obj);
    Task Atualizar(TEntity obj);
    Task<TEntity> ObterPorID(int id);
}
