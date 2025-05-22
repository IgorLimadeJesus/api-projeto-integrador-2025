using mrp_api.DTOs.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface IInsumoRepositorio
    {
        Task<InsumosModel> AddInsumo(InsumosModel insumo);
        Task<List<InsumosModel>> GetInsumos();
        Task<InsumosModel> GetInsumoById(int id);
    }
}
