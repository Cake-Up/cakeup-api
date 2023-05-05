using CakeUpERP.Domain.Entities;
using CakeUpERP.Domain.Interfaces.Repositorys;
using CakeUpERP.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Infra.Data.Repository
{
    public class CompanhiaRepository : RepositoryBase<CompanhiaEntity>, ICompanhiaRepository
    {
        public CompanhiaRepository(DataContext DbContext) : base(DbContext) { }

    }
}
