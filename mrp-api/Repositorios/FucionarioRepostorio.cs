using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class FucionarioRepostorio : IFuncionarioRepositorio
    {
        private readonly MrpDBContext _dbContext;

        public FucionarioRepostorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FuncionarioModel> AddFuncionario(FuncionarioModel user)
        {   
            await _dbContext.Funcionario.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<FuncionarioModel>> GetAllFuncionario()
        {
            return await _dbContext.Funcionario.ToListAsync();
        }

        public async Task<FuncionarioModel> GetFuncionarioById(int id)
        {
            return await _dbContext.Funcionario.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel funcionario)
        {
            FuncionarioModel Funcionario = await GetFuncionarioById(funcionario.id);

            if (Funcionario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _dbContext.Funcionario.Update(Funcionario);
            await _dbContext.SaveChangesAsync();

            return funcionario;
        }
    }
}
