using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.DTOs.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class InsumosRepositorio : IInsumoRepositorio
    {

        private readonly MrpDBContext _dbContext;

        public InsumosRepositorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<InsumosModel> AddInsumo(InsumosModel insumo)
        {
            await _dbContext.Insumos.AddAsync(insumo);
            await _dbContext.SaveChangesAsync();

            return insumo;
        }

        public Task<InsumosModel> GetInsumoById(int id)
        {
            return _dbContext.Insumos.FirstOrDefaultAsync(i => i.id == id);
        }

        public Task<List<InsumosModel>> GetInsumos()
        {
            return _dbContext.Insumos.ToListAsync();
        }
    }
}
