using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.Objects.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
    }
}
