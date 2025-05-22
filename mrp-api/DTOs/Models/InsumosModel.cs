using System.ComponentModel.DataAnnotations.Schema;
using mrp_api.Objects.Models;

namespace mrp_api.DTOs.Models
{
    [Table("Insumo")]
    public class InsumosModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Nome")]
        public string nome { get; set; }

        [Column("Tipo")]
        public string tipo { get; set; }

        [Column("Codigo")]
        public string codigo { get; set; }

        [Column("Custo")]
        public decimal custo { get; set; }

        [Column("ID_Fornecedor")]
        [ForeignKey("fornecedor")]
        public int? id_Fornecedor { get; set; }
        public FornecedorModel? fornecedor { get; set; }
    }
}