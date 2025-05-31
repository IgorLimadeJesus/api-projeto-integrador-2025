using mrp_api.Objects.Dto;

namespace mrp_api.Objects.DTOs
{
    public class definirFuncionario
    {
        public int funcionario_id { get; set; }
    }

    public class definirManutencao
    {
        public MachineStatus status { get; set; }
        public DateTime previsao { get; set; }
    }
}
