using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class SetorRepositorio : ISetorRepositorio
    {

        private readonly MrpDBContext _dbContext;

        public SetorRepositorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SetorModel> AddSetor(SetorModel setor)
        {
            await _dbContext.Setor.AddAsync(setor);
            await _dbContext.SaveChangesAsync();
            return setor;
        }
        public async Task<List<SetorModel>> GetSetor()
        {
            return await _dbContext.Setor.ToListAsync();
        }
        

        public async Task<bool> DeleteSetor(int id)
        {
            SetorModel setor = await _dbContext.Setor.FirstOrDefaultAsync(x => x.id == id);

            if(setor == null)
            {
                return false;
            }

            _dbContext.Setor.Remove(setor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
