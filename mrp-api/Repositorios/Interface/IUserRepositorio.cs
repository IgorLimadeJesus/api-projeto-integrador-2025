using mrp_api.Objects.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface IUserRepositorio
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user);
    }
}
