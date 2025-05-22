using mrp_api.Objects.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface ISetorRepositorio
    {
        Task<List<SetorModel>> GetSetor();
        Task<SetorModel> AddSetor(SetorModel model);
        Task<bool> DeleteSetor(int id);
    }
}
