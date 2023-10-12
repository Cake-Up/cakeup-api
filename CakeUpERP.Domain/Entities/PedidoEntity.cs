using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class PedidoEntity : EntityBase
    {
        public DateTime DataPedido { get; set; }
        public DateTime DataEvento { get; set; }
        public float ValorTotal { get; set; }
        public int IdStatusPedido { get; set; }
        public int IdOrcamento { get; set; }
        public int IdCliente { get; set; }
        public virtual OrcamentoEntity Orcamento { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
    }
}