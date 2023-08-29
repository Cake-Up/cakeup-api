namespace CakeUpERP.Domain.Entities
{
    public class IngredienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public decimal CustoUnitario { get; set; }
        public float QtdPorEmbalagem { get; set; }
        public int TipoEmbalagem { get; set; }
        public DateTime Validade { get; set; }
        public int IdUnidadeMedida { get; set; }
        public List<AtualizacoesPrecosEntity> AtualizacoesPrecos { get; set; }
    }
}
