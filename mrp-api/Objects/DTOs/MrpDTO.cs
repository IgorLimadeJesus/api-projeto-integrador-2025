namespace mrp_api.Objects.DTOs
{
    public class Produto_Final
    {
        public string nomeProduto { get; set; }
        public int qntdProduzida { get; set; }
        public DateTime dataEntrega { get; set; }

    }

    public class Lista_Materiais
    {
        public string nomeComponente { get; set; }
        public int qtndUnidade { get; set; }
    }

    public class Estoque_Atual
    {
        public string nomeProduto { get; set; }
        public int qntdDisponivel { get; set; }
    }

    public class Pedidos_Aberto
    {
        public string nomeItem { get; set; }
        public int qntdPedida { get; set; }
        public DateTime dataEntrega { get; set; }
    }

    public class Lead_Time
    {
        public string nomeItem { get; set; }
        public int tempoReposicao { get; set; }
    }

    public class OperacaoRecurso
    {
        public string nomeOperacao { get; set; }           // Ex: Corte
        public int tempoPorUnidadeMin { get; set; }        // Tempo por unidade (min)
        public int recursosDisponiveis { get; set; }       // Funcionários ou máquinas
        public int horasPorDia { get; set; }               // Capacidade por recurso por dia
    }
}
