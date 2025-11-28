namespace precificacaointeligente.Models
{
    public class CramerModel
    {
        // Entradas (nullable para não aparecer 0 por padrão)
        public decimal PriceA { get; set; }
        public decimal VariableCostA { get; set; }
        public decimal FixedCostA { get; set; }

        public decimal PriceB { get; set; }
        public decimal VariableCostB { get; set; }
        public decimal FixedCostB { get; set; }

        // Resultados numéricos já calculados no Controller
        public decimal A1 { get; set; }
        public decimal A2 { get; set; }
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal D { get; set; }
        public decimal Dx { get; set; }
        public decimal Dl { get; set; }
        public decimal Q { get; set; }
        public decimal L { get; set; }
        public bool HasResult { get; set; }
        public bool DeterminantZero { get; set; }

    }
}
