using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(DataContext DbContext) : base(DbContext) { }
    }
}
