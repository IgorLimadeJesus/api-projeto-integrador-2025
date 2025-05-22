using mrp_api.DTOs.Models;

namespace mrp_api.Repositorios.Interface
{
    public interface IProdutoRepositorio
    {
        Task<ProdutosModel> AddProdutos(ProdutosModel produtos);
        Task<List<ProdutosModel>> GetProdutos();
        Task<ProdutosModel> GetProdutoById(int id);
    }
}

