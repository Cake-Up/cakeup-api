using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataUpdate { get; set; }
    }
}
