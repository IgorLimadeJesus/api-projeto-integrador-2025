using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.Objects.Models
{
    [Table("Setor")]
    public class SetorModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Nome")]
        public string nome { get; set; }
    }
}
