namespace mrp_api.Objects.DTOs
{
    public class Mrp1ResultadoDto
    {
        public DateTime DataCalculo { get; set; }
        public List<RequisicaoMateriaPrimaDto> Requisicoes { get; set; }
    }

    public class Mrp2ResultadoDto
    {
        public DateTime DataCalculo { get; set; }
        public List<OrdemProducaoDto> OrdensDeProducao { get; set; }
        public List<MaquinaAlocadaDto> MaquinasAlocadas { get; set; }
    }
}