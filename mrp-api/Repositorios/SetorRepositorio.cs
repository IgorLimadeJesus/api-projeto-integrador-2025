using mrp_api.Objects.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class SetorRepositorio : ISetorRepositorio
    {
        public Task<SetorModel> AddSetor(SetorModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSetor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SetorModel>> GetSetor()
        {
            throw new NotImplementedException();
        }
    }
}
