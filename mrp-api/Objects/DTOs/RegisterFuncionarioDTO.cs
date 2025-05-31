using mrp_api.Objects.Dto;
using mrp_api.Objects.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.Objects.DTOs
{
    public class RegisterFuncionarioDTO
    {
        public string nome { get; set; }
        public int id_Cargo { get; set; }
        public int id_Setor { get; set; }
        public int hierarquia { get; set; }
        public UserStatus status { get; set; }
        public decimal salario { get; set; }
        public int matricula { get; set; }
        public int? id_Maquina { get; set; }
        public string senha { get; set; }
    }
}
