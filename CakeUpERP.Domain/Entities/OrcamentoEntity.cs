using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class OrcamentoEntity : EntityBase
    {
        public DateTime DataOrcamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public DateTime DataEvento { get; set; }
        public string CodReferencia { get; set; }
        public string Titulo { get; set; }
        public int IdStatusOrcamento { get; set; }
        public int IdCliente { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual PedidoEntity Pedido { get; set; }
        public virtual ICollection<RlItensOrcamento> ItensOrcamentos { get; set; }
    }
}