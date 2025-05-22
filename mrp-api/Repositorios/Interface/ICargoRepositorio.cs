using mrp_api.Objects.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface ICargoRepositorio
    {
        Task<List<CargoModel>> GetCargo();
        Task<CargoModel> AddCargo(CargoModel cargo);
    }
}