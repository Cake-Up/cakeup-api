using System;
using System.Collections.Generic;
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

        public CompanhiaEntity Companhia { get; set; }
        public List<ObservacaoClienteEntity> ObservacaoClienteEntities { get; set; }

    }
}
