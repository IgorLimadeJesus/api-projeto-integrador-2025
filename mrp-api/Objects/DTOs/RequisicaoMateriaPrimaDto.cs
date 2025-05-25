namespace mrp_api.Objects.DTOs
{
    public class RequisicaoMateriaPrimaDto
    {
        public string CodigoInsumo { get; set; }
        public string NomeInsumo { get; set; }
        public int QuantidadeNecessaria { get; set; }
        public DateTime DataNecessaria { get; set; }
        public string ProdutoOrigem { get; set; }
    }
}
