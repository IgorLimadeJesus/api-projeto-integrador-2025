using mrp_api.DTOs.Models;
using mrp_api.Objects.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace mrp_api.Objects.DTOs
{

    public class RegisterModelCalculo
    {
        public Produto_Final ProdutoFinal { get; set; }
        public List<Lista_Materiais> ListaMateriais { get; set; }
        public List<Estoque_Atual> EstoqueAtual { get; set; }
        public List<Pedidos_Aberto> PedidosAbertos { get; set; }
        public List<Lead_Time> LeadTimes { get; set; }
        public List<OperacaoRecurso> RecursosProducao { get; set; }
    }

    public class RegisterModelProdutos
    {
        public string nome { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }
        public int? id_Maquina { get; set; }
        public int? id_Funcionario { get; set; }
        public int quantidade { get; set; }
        public decimal custo { get; set; }
    }

    public class RegiterModelInsumo
    {
        public string nome { get; set; }
        public string tipo { get; set; }
        public string codigo { get; set; }
        public decimal custo { get; set; }
        public int? id_Fornecedor { get; set; }
    }

}
