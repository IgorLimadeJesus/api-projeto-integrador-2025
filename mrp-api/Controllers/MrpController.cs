using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mrp_api.Data;
using mrp_api.DTOs.Models;
using mrp_api.DTOs.Objects;
using mrp_api.Repositorios.Interface;

namespace mrp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MrpController : ControllerBase
    {
        private readonly MrpDBContext _dbContext;

        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IInsumoRepositorio _insumoRepositorio;

        public MrpController(IProdutoRepositorio produtoRepositorio, MrpDBContext mrpDBContext, IInsumoRepositorio insumoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _insumoRepositorio = insumoRepositorio;
            _dbContext = mrpDBContext;
        }

        //Crud Produtos
        [HttpPost("/Produtos/Cadastro")]
        public async Task<ActionResult<List<ProdutosModel>>> CadastroProduto([FromForm] RegisterModelProdutos registerModelProdutos)
        {
            var Produtos = new ProdutosModel
            {
                nome = registerModelProdutos.nome,
                tipo = registerModelProdutos.tipo,
                codigo = registerModelProdutos.codigo,
                id_Maquina = registerModelProdutos.id_Maquina,
                id_Funcionario = registerModelProdutos.id_Funcionario,
                quantidade = registerModelProdutos.quantidade,
                custo = registerModelProdutos.custo
            };

            if (Produtos == null)
            {
                return BadRequest(new { Error = "Produto não pode ser nulo" });
            }

            ProdutosModel produtosModel = await _produtoRepositorio.AddProdutos(Produtos);
            return Ok( new { Sucess = "Produto Cadastrado com sucesso" } );
        }

        [HttpGet("/Produtos/Consulta")]
        public async Task<ActionResult<List<ProdutosModel>>> ConsultaProduto()
        {
            List<ProdutosModel> produtos = await _produtoRepositorio.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("/Produtos/Consulta/{id}")]
        public async Task<ActionResult<List<ProdutosModel>>> ConsultaProdutoPorId(int id)
        {
            ProdutosModel produtos = await _produtoRepositorio.GetProdutoById(id);
            return Ok(produtos);
        }

        //Crud Insumos
        [HttpPost("/Insumos/Cadastro")]
        public async Task<ActionResult<List<InsumosModel>>> CadastrarInsumos([FromForm] RegiterModelInsumo regiterModelInsumo)
        {
            var Insumos = new InsumosModel
            {
                nome = regiterModelInsumo.nome,
                tipo = regiterModelInsumo.tipo,
                codigo = regiterModelInsumo.codigo,
                custo = regiterModelInsumo.custo,
                id_Fornecedor = regiterModelInsumo.id_Fornecedor
            };

            InsumosModel insumos = await _insumoRepositorio.AddInsumo(Insumos);
            return Ok(new { Sucess = "Insumo Cadastrado com sucesso" });
        }

        [HttpGet("/Insumos/Consulta")]
        public async Task<ActionResult<List<InsumosModel>>> ConsultaInsumos()
        {
            List<InsumosModel> insumos = await _insumoRepositorio.GetInsumos();
            return Ok(insumos);
        }

        [HttpGet("/Insumos/Consulta/{id}")]
        public async Task<ActionResult<List<InsumosModel>>> ConsultaInsumosPorId(int id)
        {
            InsumosModel insumos = await _insumoRepositorio.GetInsumoById(id);
            return Ok(insumos);
        }
    }
}
