using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class RlUtensiliosReceita : EntityBase
    {
        public int idReceita { get; set; }
        public int idUtensilio { get; set; }
        public UtensiliosEEquipamentosEntity Utensilios { get; set; }
        public ReceitaEntity Receita { get; set; }
    }
}
