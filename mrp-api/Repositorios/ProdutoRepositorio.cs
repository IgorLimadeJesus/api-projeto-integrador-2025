using Microsoft.EntityFrameworkCore;
using mrp_api.Data;
using mrp_api.DTOs.Models;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MrpDBContext _dbContext;

        public ProdutoRepositorio(MrpDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutosModel> AddProdutos(ProdutosModel produtos)
        {
            await _dbContext.Produto.AddAsync(produtos);
            await _dbContext.SaveChangesAsync();

            return produtos;
        }

        public async Task<ProdutosModel> GetProdutoById(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<ProdutosModel>> GetProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }
    }
}
