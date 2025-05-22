using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class UserRepostorio : IUserRepositorio
    {
        private readonly MrpDBContext _dbContext;

        public UserRepostorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {   
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            UserModel userModel = await GetUserById(user.id);

            if (userModel == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _dbContext.Users.Update(userModel);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
