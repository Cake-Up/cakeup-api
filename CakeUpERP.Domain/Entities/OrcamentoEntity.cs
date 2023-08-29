using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class OrcamentoEntity
    {
        public DateTime DataOrcamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public DateTime DataEvento { get; set; }
        public string Titulo { get; set; }
        public int IdStatusOrcamento { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual ReceitaEntity Receita { get; set; }

    }
}
