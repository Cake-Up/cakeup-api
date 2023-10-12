using System.Collections.ObjectModel;

namespace CakeUpERP.Domain.Entities
{
    public class IngredienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public float CustoUnitario { get; set; }
        public int QtdPorEmbalagem { get; set; }
        public int TipoEmbalagem { get; set; }
        public DateTime Validade { get; set; }
        public int IdUnidadeMedida { get; set; }
        public virtual ICollection<MovimentacoesIngredientes> MovimentacoesIngredientes { get; set; }
        public virtual ICollection<RlIngredientesReceita> ReceitasIngredientes { get; set; }
        public virtual ICollection<RlItensOrcamento> RlItensOrcamentos { get; set; }

    }
}