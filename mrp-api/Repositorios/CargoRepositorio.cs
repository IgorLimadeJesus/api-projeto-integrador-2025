using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly MrpDBContext _dbContext;

        public CargoRepositorio (MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CargoModel> AddCargo(CargoModel cargo)
        {
            await _dbContext.Cargo.AddAsync(cargo);
            await _dbContext.SaveChangesAsync();

            return cargo;
        }

        public async Task<List<CargoModel>> GetCargo()
        {
            return await _dbContext.Cargo.ToListAsync();
        }
    }
}
