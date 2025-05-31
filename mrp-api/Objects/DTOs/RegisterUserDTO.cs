namespace mrp_api.Objects.DTOs
{
    public class RegisterUserDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
    }
}
