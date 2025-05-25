using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mrp_api.Data;
using mrp_api.DTOs.Models;
using mrp_api.Objects.Models;
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

            [HttpPost("/MRP/Calcular")]
            public async Task<ActionResult> CalcularMRP([FromBody] RegisterModelCalculo dados)
            {
                var resultado = new List<object>();

                foreach (var componente in dados.ListaMateriais)
                {
                    var nome = componente.nomeComponente;

                    // Necessidade bruta: quantidade final * quantidade por unidade
                    int necessidadeBruta = dados.ProdutoFinal.qntdProduzida * componente.qtndUnidade;

                    // Estoque disponível
                    int estoque = dados.EstoqueAtual
                        .FirstOrDefault(x => x.nomeProduto == nome)?.qntdDisponivel ?? 0;

                    // Pedidos em aberto que chegam antes ou no dia da entrega
                    int pedidosAbertos = dados.PedidosAbertos
                        .Where(p => p.nomeItem == nome && p.dataEntrega <= dados.ProdutoFinal.dataEntrega)
                        .Sum(p => p.qntdPedida);

                    // Necessidade líquida
                    int necessidadeLiquida = Math.Max(necessidadeBruta - (estoque + pedidosAbertos), 0);

                    // Lead time do item
                    int leadTimeDias = dados.LeadTimes
                        .FirstOrDefault(x => x.nomeItem == nome)?.tempoReposicao ?? 0;

                    // Data do pedido
                    DateTime dataPedido = dados.ProdutoFinal.dataEntrega.AddDays(-leadTimeDias);

                    resultado.Add(new
                    {
                        NomeItem = nome,
                        NecessidadeBruta = necessidadeBruta,
                        EstoqueDisponivel = estoque,
                        PedidosEmAberto = pedidosAbertos,
                        NecessidadeLiquida = necessidadeLiquida,
                        DataPedido = necessidadeLiquida > 0 ? dataPedido.ToString("yyyy-MM-dd") : "Sem necessidade"
                    });
                }

                    // MRP II - Planejamento de recursos produtivos (mão de obra/máquinas)
                var planejamentoRecursos = new List<object>();

                if (dados.RecursosProducao != null)
                {
                    foreach (var operacao in dados.RecursosProducao)
                    {
                        int minutosTotais = dados.ProdutoFinal.qntdProduzida * operacao.tempoPorUnidadeMin;
                        int horasNecessarias = (int)Math.Ceiling(minutosTotais / 60.0);

                        int diasDisponiveis = (dados.ProdutoFinal.dataEntrega - DateTime.Today).Days;
                        int capacidadeTotal = operacao.recursosDisponiveis * operacao.horasPorDia * diasDisponiveis;

                        planejamentoRecursos.Add(new
                        {
                            Operacao = operacao.nomeOperacao,
                            HorasNecessarias = horasNecessarias,
                            CapacidadeDisponivel = capacidadeTotal,
                            Suficiente = capacidadeTotal >= horasNecessarias ? "Sim" : "Não"
                        });
                    }
                }


                return Ok(new
                {
                    Sucesso = "Cálculo do MRP realizado com sucesso.",
                    OrdensPlanejadas = resultado
                });
            }

    }
}
