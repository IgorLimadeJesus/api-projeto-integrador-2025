using mrp_api.Objects.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface IFuncionarioRepositorio
    {
        Task<List<FuncionarioModel>> GetAllFuncionario();
        Task<FuncionarioModel> GetFuncionarioById(int id);
        Task<FuncionarioModel> AddFuncionario(FuncionarioModel user);
        Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel user);
    }
}
