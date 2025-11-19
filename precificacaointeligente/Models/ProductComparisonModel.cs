namespace precificacaointeligente.Models
{
    public class ProductComparisonModel
    {
        // Entradas (formulário)
        public double PriceA { get; set; }
        public double VariableCostA { get; set; }
        public double FixedCostA { get; set; }

        public double PriceB { get; set; }
        public double VariableCostB { get; set; }
        public double FixedCostB { get; set; }

        // Resultados numéricos (preenchidos pelo controller)
        public double? QuantityBreakEven { get; set; }     // Q
        public double? ProfitAtBreakEven { get; set; }     // L

        // Coeficientes usados para exibir o passo a passo
        public double A1 { get; set; }  // (PA - CVA)
        public double A2 { get; set; }  // (PB - CVB)
        public double C1 { get; set; }  // CFA
        public double C2 { get; set; }  // CFB

        // Determinantes
        public double D { get; set; }
        public double Dx { get; set; }
        public double Dl { get; set; }
    }
}
