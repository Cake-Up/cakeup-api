using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class ClienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public char Genero { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int IdCompanhia { get; set; }

        public virtual CompanhiaEntity Companhia { get; set; }
        public virtual ICollection<OrcamentoEntity> OrcamentosCliente { get; set; }
        public virtual ICollection<PedidoEntity> PedidosCliente { get; set; }
        public virtual ICollection<ObservacaoClienteEntity> ObservacaoClienteEntities { get; set; }

    }
}
