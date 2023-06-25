using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class ObservacaoClienteEntity : EntityBase
    {
        public int IdCliente { get; set; }
        public DateTime DataObservacao { get; set; }
        public string Observacao { get; set; }

        public ClienteEntity Cliente { get; set; }
    }
}