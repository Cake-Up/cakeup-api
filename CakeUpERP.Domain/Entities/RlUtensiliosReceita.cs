using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class RlUtensiliosReceita : EntityBase
    {
        public int IdReceita { get; set; }
        public int IdUtensilio { get; set; }
        public virtual UtensiliosEEquipamentosEntity Utensilios { get; set; }
        public virtual ReceitaEntity Receita { get; set; }
    }
}
