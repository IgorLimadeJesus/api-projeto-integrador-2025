using mrp_api.Objects.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface IMachineRepositorio
    {
        Task<MachineModel> AddMaquinas(MachineModel model);
        Task<List<MachineModel>> GetMaquinas();
        Task<MachineModel> GetMaquinasById(int id);
    }
}
