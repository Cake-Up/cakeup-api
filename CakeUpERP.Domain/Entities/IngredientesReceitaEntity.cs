using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class IngredientesReceitaEntity : EntityBase
    {
        public int IdIngrediente { get; set; }
        public int IdReceita { get; set; }
        public DateTime DataFabricacao { get; set; }

    }
}
