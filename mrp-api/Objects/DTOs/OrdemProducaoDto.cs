namespace mrp_api.Objects.DTOs
{
    public class OrdemProducaoDto
    {
        public string CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeProduzir { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<EtapaProducaoDto> Etapas { get; set; }
    }
}
