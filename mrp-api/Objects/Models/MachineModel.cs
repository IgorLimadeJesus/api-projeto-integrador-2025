using System.ComponentModel.DataAnnotations.Schema;
using mrp_api.Objects.Dto;

namespace mrp_api.Objects.Models
{

    [Table("Maquina")]
    public class MachineModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Modelo")]
        public string modelo { get; set; }

        [Column("Status")]
        public MachineStatus status { get; set; }

        [Column("ID_Funcionario")]
        public int? id_Funcionario { get; set; }
        public FuncionarioModel? funcionario { get; set; }

        [Column("Codigo")]
        public string codigo { get; set; }

        [Column("Custo_Por_Hora")]
        public decimal? cph { get; set; }

        [Column("Previsao_Manutencao")]
        public DateTime? previsao_Manutencao { get; set; }
        
    }
}
