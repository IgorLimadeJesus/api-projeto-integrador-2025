using System.ComponentModel.DataAnnotations.Schema;
using mrp_api.Objects.Dto;

namespace mrp_api.Objects.Models
{
    [Table("Funcionario")]
    public class FuncionarioModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Nome")]
        public string nome { get; set; }

        [Column("ID_Cargo")]
        public int id_Cargo { get; set; }

        [ForeignKey("id_Cargo")]
        public CargoModel? cargo { get; set; }

        [Column("ID_Setor")]
        public int id_Setor { get; set; }
        [ForeignKey("id_Setor")]
        public SetorModel? setor { get; set; }

        [Column("Hierarquia")]
        public int hierarquia { get; set; }

        [Column("Status_")]
        public UserStatus status {  get; set; }

        [Column("Salario")]
        public decimal salario { get; set; }

        [Column("Matricula")]
        public int matricula { get; set; }

        [Column("ID_Maquina")]
        [ForeignKey("maquina")]
        public int? id_Maquina { get; set; }
        public MachineModel? maquina { get; set; }

        [Column("Senha")]
        public string senha { get; set; }
    }
}
