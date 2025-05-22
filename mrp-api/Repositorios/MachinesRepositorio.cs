using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class MachinesRepositorio : IMachineRepositorio
    {
        private readonly MrpDBContext _dbContext;

        public MachinesRepositorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MachineModel> AddMaquinas(MachineModel machine)
        {
            await _dbContext.AddAsync(machine);
            await _dbContext.SaveChangesAsync();

            return machine;
        }

        public async Task<List<MachineModel>> GetMaquinas()
        {
            return await _dbContext.Machines.ToListAsync();
        }

        public async Task<MachineModel> GetMaquinasById(int id)
        {
            return await _dbContext.Machines.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
