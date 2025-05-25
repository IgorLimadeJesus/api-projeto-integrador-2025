namespace mrp_api.Objects.DTOs
{
    public class EtapaProducaoDto
    {
        public string NomeFase { get; set; } // Ex: Corte, Costura
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
