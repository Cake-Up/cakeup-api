using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeUpERP.Domain.Entities
{
    public class ReceitaEntity : EntityBase
    {
        public string Nome { get; set; }
        public decimal CustoReceita { get; set; }
        public int Rendimento { get; set; }
        public string EndereçoImagem { get; set; }
        public decimal Peso { get; set; }
        public string ModoDePreparo { get; set; }
        public List<IngredienteEntity> Ingrediente { get; set; }
        public List<UtensiliosEEquipamentosEntity> UtensiliosEEquipamentos { get; set; }
    }
}
