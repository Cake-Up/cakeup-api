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
        public virtual List<MovimentacoesIngredientes> MovimentacoesIngredientes { get; set; }
        public virtual List<RlIngredientesReceita> ReceitasIngredientes { get; set; }

    }
}