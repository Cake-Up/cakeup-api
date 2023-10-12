using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class MovimentacoesIngredientes: EntityBase
    {
        public DateTime DataMovimentacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Descricao { get; set; }
        public int? IdReceita { get; set; }
        public int? IdIngrediente { get; set; }
        public int QtdProduto { get; set; }
        public float Preco { get; set; }
        public IngredienteEntity Ingrediente { get; set; }
        public ReceitaEntity Receita { get; set; }
    }
}
