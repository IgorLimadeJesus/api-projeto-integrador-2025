using System.ComponentModel.DataAnnotations.Schema;
using mrp_api.Objects.Models;

namespace mrp_api.DTOs.Models
{
    [Table("Produto")]
    public class ProdutosModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Nome")]
        public string nome { get; set; }

        [Column("Tipo")]
        public string tipo { get; set; }

        [Column("Codigo")]
        public string codigo { get; set; }

        [Column("ID_Maquina")]
        [ForeignKey("maquina")]
        public int? id_Maquina { get; set; }
        public MachineModel? maquina { get; set; }

        [Column("ID_Funcionario")]
        [ForeignKey("funcionario")]
        public int? id_Funcionario { get; set; }
        public FuncionarioModel? funcionario { get; set; }

        [Column("Qntd")]
        public int quantidade { get; set; }

        [Column("Custo")]
        public decimal custo { get; set; }
    }
}