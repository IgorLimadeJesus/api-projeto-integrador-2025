using mrp_api.Objects.Models;

namespace mrp_api.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserModel user);
    }
}
