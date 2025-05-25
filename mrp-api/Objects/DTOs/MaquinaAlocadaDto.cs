namespace mrp_api.Objects.DTOs
{
    public class MaquinaAlocadaDto
    {
        public string NomeMaquina { get; set; }
        public string CodigoMaquina { get; set; }
        public string Produto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TempoMinutos { get; set; }
    }
}
