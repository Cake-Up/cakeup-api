using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class RlIngredientesReceita : EntityBase
    {
        public int IdReceita { get; set; }
        public int IdIngrediente { get; set; }
        public virtual ReceitaEntity Receita { get; set; }
        public virtual IngredienteEntity Ingrediente { get; set; }
    }
}
