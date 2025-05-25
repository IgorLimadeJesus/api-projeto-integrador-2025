using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.DTOs.Models
{
    [Table("Fornecedor")]
    public class FornecedorModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("Nome")]
        public string nome { get; set; }

        [Column("Contato")]
        public string contato { get; set; }

        [Column("CNPJ_CPF")]
        public string cpf_cnpj { get; set; }
        
        [Column("CEP")]
        public string cep { get; set; }

        [Column("Rua")]
        public string rua { get; set; }

        [Column("Bairro")]
        public string bairro { get; set; }

        [Column("Numero")]
        public int numero { get; set; }

        [Column("Complemento")]
        public string complemento { get; set; }

        [Column("Pais")]
        public string pais { get; set; }

        [Column("Estado")]
        public string estado { get; set; } 
    }
}
