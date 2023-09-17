using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class ReceitaEntity : EntityBase
    {
        public string Nome { get; set; }
        public float CustoReceita { get; set; }
        public int Rendimento { get; set; }
        public string EndereçoImagem { get; set; }
        public float Peso { get; set; }
        public string ModoDePreparo { get; set; }
        public DateTime DataPreparo { get; set; }
        public virtual ICollection<RlIngredientesReceita> Ingrediente { get; set; }
        public virtual ICollection<UtensiliosEEquipamentosEntity> UtensiliosEEquipamentos { get; set; }
    }
}
