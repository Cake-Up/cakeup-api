using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Filters.Bases
{
    public abstract class PaginationBase
    {
        public int QtdRegistros { get; set; }
        public int Skip { get; set; }
    }
}
