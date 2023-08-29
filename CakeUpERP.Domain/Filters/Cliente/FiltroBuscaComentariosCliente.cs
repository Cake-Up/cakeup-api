using CakeUpERP.Domain.Filters.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Cliente
{
    public class FiltroBuscaObservacaoCliente : PaginationBase
    {
        public int IdCliente { get; set; }
    }
}
