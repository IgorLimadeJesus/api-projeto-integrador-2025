using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.Objects.DTOs
{
    public class FornecedorDTO
    {
        public string nome { get; set; }
        public string contato { get; set; }
        public string cpf_cnpj { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
    }
}
