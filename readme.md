**ÍNDICE**
[[DOCS - API ERP(MRP-I, MRP-II)#1. Introdução|1. Introdução]]
[[DOCS - API ERP(MRP-I, MRP-II)#2. Arquitetura do Sistema|2. Arquitetura do Sistema]]
- [[DOCS - API ERP(MRP-I, MRP-II)#2.1 Interface de Software|2.1 Interface de Software]]

[[DOCS - API ERP(MRP-I, MRP-II)#3. Endpoints|3. Endpoints]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.1 Funcionarios|3.1 Funcionarios]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.2 EstoqueInsumo|3.2 EstoqueInsumo]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.3 EstoqueProduto|3.3 EstoqueProduto]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.4 EntradaInsumo|3.4 EntradaInsumo]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.5 SaidaProduto|3.5 SaidaProduto]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.6 SaidaInsumo|3.6 SaidaInsumo]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.7 Maquinas|3.7 Maquinas]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.8 CalculoProducao|3.8 CalculoProducao]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.9 Insumos|3.9 Insumos]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.10 Produtos|3.10 Produtos]]
- [[DOCS - API ERP(MRP-I, MRP-II)#3.11 Usuarios|3.11 Usuarios]]

[[DOCS - API ERP(MRP-I, MRP-II)#==4. Models e Repositórios== to-do|4. Models e Repositórios]]
- [[DOCS - API ERP(MRP-I, MRP-II)#4.1 Models|4.1 Models]]
- [[DOCS - API ERP(MRP-I, MRP-II)#4.2 Repositórios|4.2 Repositórios]]

[[DOCS - API ERP(MRP-I, MRP-II)#==5. Diagramas== to-do|5 Diagramas]]
- [[DOCS - API ERP(MRP-I, MRP-II)#5.1 Sequência|5.2 Sequência]]

	- [[DOCS - API ERP(MRP-I, MRP-II)#5.1.1 Por Requisito Funcional (MRP-I)|5.1.1 Por Requisito Funcional (MRP-I)]]
	- [[DOCS - API ERP(MRP-I, MRP-II)#5.1.2 Por Requisito Funcional (MRP-II)|5.1.2 Por Requisito Funcional (MRP-II)]]

- [[DOCS - API ERP(MRP-I, MRP-II)#5.2 Caso de Uso|5.2 Caso de Uso]]
	- [[DOCS - API ERP(MRP-I, MRP-II)#5.2.1 Por Requisito Funcional (MRP-I)|5.2.1 Por Requisito Funcional (MRP-I)]]
	- [[DOCS - API ERP(MRP-I, MRP-II)#5.2.2 Por Requisito Funcional (MRP-II)|5.2.2 Por Requisito Funcional (MRP-I)]]


───────── ❖ ─────────

**TO-DO's** #to-do
↪ Realizar documentação dentro do código p/ melhor esclarecimento nas Models e Repositórios (Item 4)

---
---
# 1. Introdução
O documento descreve a estrutura, funcionamento e padronização no backend para o sistema ERP(MRP-I | MRP-II), auxiliando o gerenciamento e produção para uma indústria têxtil, focada em vestimentas.

---
# 2. Arquitetura do Sistema
O backend irá utilizar a linguagem de programação **C# .NET** com uma abordagem **RESTful** para endpoints. Haverá **controllers distintas** entre MRP's, onde terá uma comunicação direta entre as mesmas.

**Informações estruturais**
- **Variáveis:** camelCase
- **Classes e Métodos:** PascalCase
- **Servidor:** Externo
- **Local de teste:** Swagger

## 2.1 Interface de Software
A interface entre os sistemas MRP I e MRP II segue os seguintes princípios:

- **Comunicação via HTTP RESTful**, sem autenticação implementada até o momento.
- **MRP II realiza chamadas para o MRP I** para acessar cálculos ou dados necessários. Ou seja, o MRP II funciona como uma extensão do MRP I, englobando e integrando os cálculos de ambos.
- Ambos compartilham **o mesmo banco de dados físico**, mas utilizam **tabelas distintas** para manter a organização e o isolamento lógico entre os domínios.
	⭢ **Exemplo:** existe uma tabela de máquinas utilizada apenas pelo MRP II.
- As chamadas entre os sistemas são feitas por meio de requisições HTTP internas, considerando que ambos estão hospedados em um mesmo ambiente controlado.

Essa abordagem garante uma integração modular e escalável, permitindo que os módulos MRP evoluam separadamente, mas ainda mantendo a coesão necessária entre as operações de planejamento e produção.

---
# 3. Endpoints
## 3.1 Funcionarios
```
GET https://localhost:porta/api/MRP1/Operadores
POST https://localhost:porta/api/MRP1/Operadores

	"ID" : 0,
	"Nome" : "String",
	"Matricula" : "String",
	"Maquina" : 0,
	"Cargo" : "String",
	"Hierarquia" : 0,
	"Setor" : "String",
	"Status" : 0
```

## 3.2 EstoqueInsumo
```
GET https://localhost:porta/api/MRP1/EstoqueMaterial
POST https://localhost:porta/api/MRP1/Operadores

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Fornecedor" : "String",
	"Qntd" : "String"
```

## 3.3 EstoqueProduto
```
GET https://localhost:porta/api/MRP1/EstoqueProduto
GET https://localhost:porta/api/MRP1/EstoqueProduto/{id}
POST https://localhost:porta/api/MRP1/EstoqueProduto

	"ID" : 0,
	"Nome" : "String",
	"Tipo": "String",
	"Codigo" : "String",
	"Operador" : 0,
	"Maquina" : 0,
	"Qntd" : 0
```

## 3.4 EntradaInsumo
```
GET https://localhost:porta/api/MRP1/LogEntrada
POST https://localhost:porta/api/MRP1/LogEntrada

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Transportadora" : "String",
	"Fornecedor" : "String",
	"DataEntrada" : data
```

## 3.5 SaidaProduto
```
GET https://localhost:porta/api/MRP1/LogSaida
POST https://localhost:porta/api/MRP1/LogSaida

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Transportadora" : "String",
	"DataSaida" : data
```

## 3.6 SaidaInsumo
```
GET https://localhost:porta/api/MRP1/LogSaida
POST https://localhost:porta/api/MRP1/LogSaida

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Transportadora" : "String",
	"Setor" : "String",
	"DataSaida" : data
```

## 3.7 Maquinas
```
GET https://localhost:porta/api/MRP2/Machines
POST https://localhost:porta/api/MRP2/Machines
GET https://localhost:porta/api/MRP2/Machines/{id}
DELETE https://localhost:porta/api/MRP2/Machines/delete/{id}
PUT https://localhost:porta/api/MRP2/Machines/define/{id}

	"ID" : 0,
	"Modelo" : "String",
	"Status" : "String",
	"Operador" : "String",
	"SerialNumber" : "String",
	"CPH" : "String"
```

## 3.8 CalculoProducao
```
GET https://localhost:porta/api/MRP2/Production/calcular

	"maquinaId": 1,
	"produtoId": 2,
	"qntdDesejada": 10

```

## 3.9 Insumos
```
GET https://localhost:porta/api/MRP2/Insumos
POST https://localhost:porta/api/MRP2/Insumos
GET https://localhost:porta/api/MRP2/Insumos/{id}
DELETE https://localhost:porta/api/MRP2/Insumos/delete/{id}

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Fornecedor" : "String",
	"Quantidade" : 0
```

## 3.10 Produtos
```
GET https://localhost:porta/api/MRP2/Products
POST https://localhost:porta/api/MRP2/Products
GET https://localhost:porta/api/MRP2/Products/{id}
DELETE https://localhost:porta/api/MRP2/Products/delete/{id}

	"ID" : 0,
	"Nome" : "String",
	"Tipo" : "String",
	"Codigo" : "String",
	"Quantidade" : 0
```

## 3.11 Usuarios
```
GET https://localhost:porta/api/User/usuarios
GET https://localhost:porta/api/User/usuarios/{id}
POST https://localhost:porta/api/User/register
POST https://localhost:porta/api/User/login

	"ID" : 0,
	"Nome" : "String",
	"Matricula" : "String",
	"Senha" : "String",
	"Cargo" : "String",
	"Hierarquia" : 0,
	"Setor" : "String"
```

---
# ==4. Models e Repositórios== #to-do
Abaixo estão descritas as principais **models** utilizadas no sistema e os **repositórios** responsáveis por suas operações:

## 4.1 Models
### Usuario
```csharp
public class UserModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Senha { get; set; }
    public string Cargo { get; set; }
    public int Hierarquia { get; set; }
    public string Setor { get; set; }
    public int Maquina { get; set; }
    public UserStatus Status { get; set; }
}
```

### Insumos
```csharp
public class InsumosModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Codigo { get; set; }
    public int Qntd { get; set; }
    public float Custo { get; set; }
    public int Id_Fornecedor { get; set; }
}
```

### Maquinas
```csharp
public class MachinesModel {
    public int Id { get; set; }
    public string Modelo { get; set; }
    public MachinesStatus Status { get; set; }
    public int IdUser { get; set; }
    public UserModel? User { get; set; }
    public string SerialNumber { get; set; }
    public string CPH { get; set; }
}
```

### Produtos
```csharp
public class ProductsModel {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Codigo { get; set; }
    public int Id_Maquina { get; set; }
    public MachinesModel? MachinesID { get; set; }
    public int Id_Funcionario { get; set; }
    public UserModel? UserID { get; set; }
    public int Qntd { get; set; }
    public decimal Custo { get; set; }
}
```

### Validação de Login
```csharp
public class ValidationModel {
    public string Matricula { get; set; }
    public string Senha { get; set; }
}
```

## 4.2 Repositórios
### Usuario
```csharp
public class UserRepostorio : IUserRepostorio {
    private readonly UserDBContext _dbContext;

    public UserRepostorio(UserDBContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<UserModel> AddUser(UserModel user) {
        Console.WriteLine($"Adicionando usuário: {user.Nome}");
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<UserModel>> GetAllUsers() {
        Console.WriteLine("Buscando todos os usuários");
        return await _dbContext.Users.ToListAsync();
    }

    public Task<UserModel> GetUser(int id) {
        Console.WriteLine($"Buscando usuário com ID: {id}");
        return _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserModel> AuthenticUser(ValidationModel login) {
        Console.WriteLine($"Autenticando usuário com matrícula: {login.Matricula}");
        var usuario = await _dbContext.Users.FirstOrDefaultAsync(u => u.Matricula == login.Matricula);

        if (usuario == null || usuario.Senha != login.Senha) {
            throw new Exception("Usuário ou Senha incorretos");
        }

        return usuario;
    }
}
```

### Insumos
```csharp
public class InsumosRepositorio : IInsumosRepositorio {
    private readonly AppDbContext _context;

    public InsumosRepositorio(AppDbContext context) {
        _context = context;
    }

    public async Task<List<InsumosModel>> GetAll() {
        return await _context.Insumos.ToListAsync();
    }

    public async Task<InsumosModel> GetById(int id) {
        return await _context.Insumos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<InsumosModel> Create(InsumosModel insumo) {
        _context.Insumos.Add(insumo);
        await _context.SaveChangesAsync();
        return insumo;
    }

    public async Task<bool> Delete(int id) {
        var insumo = await _context.Insumos.FirstOrDefaultAsync(x => x.Id == id);
        if (insumo == null) return false;

        _context.Insumos.Remove(insumo);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

### Maquinas
```csharp
public class MachinesRepositorio : IMachinesRepositorio {
    private readonly AppDbContext _context;

    public MachinesRepositorio(AppDbContext context) {
        _context = context;
    }

    public async Task<List<MachinesModel>> GetAll() {
        return await _context.Machines.Include(m => m.User).ToListAsync();
    }

    public async Task<MachinesModel> GetById(int id) {
        return await _context.Machines.Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MachinesModel> Create(MachinesModel machine) {
        _context.Machines.Add(machine);
        await _context.SaveChangesAsync();
        return machine;
    }

    public async Task<bool> Delete(int id) {
        var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id);
        if (machine == null) return false;

        _context.Machines.Remove(machine);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

### Produtos
```csharp
public class ProductsRepositorio : IProductsRepositorio {
    private readonly AppDbContext _context;

    public ProductsRepositorio(AppDbContext context) {
        _context = context;
    }

    public async Task<List<ProductsModel>> GetAll() {
        return await _context.Produtos
            .Include(p => p.MachinesID)
            .Include(p => p.UserID)
            .ToListAsync();
    }

    public async Task<ProductsModel> GetById(int id) {
        return await _context.Produtos
            .Include(p => p.MachinesID)
            .Include(p => p.UserID)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ProductsModel> Create(ProductsModel produto) {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> Delete(int id) {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null) return false;

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

---

# 5. Diagramas
## 5.1 Sequência
**FLUXO CÁLCULO MRP - I/II**
```mermaid
sequenceDiagram

    title Diagrama de Sequência - Fluxo Completo do Sistema

  

    participant Interface as "Interface (Front-end)"

    participant API_MRP2 as "API MRP II (Back-end)"

    participant Servico_MRP2 as "Serviço MRP II"

    participant HTTP_MRP1 as "Requisição HTTP MRP I"

    participant API_MRP1 as "API MRP I (Back-end)"

    participant Servico_MRP1 as "Serviço MRP I"

    participant BD as "Banco de Dados"

  

    Usuario->>Interface: Interage com a interface (ex: clicar em 'Calcular Produção')

    Interface->>API_MRP2: Envia solicitação POST /calcular-producao

    API_MRP2->>Servico_MRP2: Inicia cálculo de produção (MRP II)

    Servico_MRP2->>HTTP_MRP1: Chama cálculo do MRP I via HTTP

    HTTP_MRP1->>API_MRP1: Envia solicitação POST /calculo-mrp1

    API_MRP1->>Servico_MRP1: Executa lógica do MRP I

    Servico_MRP1->>BD: Consulta dados (estoque, produtos, insumos)

    BD-->>Servico_MRP1: Retorna dados para o cálculo

    Servico_MRP1-->>API_MRP1: Retorna resultado do MRP I

    API_MRP1-->>HTTP_MRP1: Resposta com dados processados

    HTTP_MRP1-->>Servico_MRP2: Recebe e integra resultados do MRP I

    Servico_MRP2->>BD: Consulta/atualiza dados adicionais (ex: máquinas, capacidade)

    BD-->>Servico_MRP2: Retorna dados

    Servico_MRP2-->>API_MRP2: Resultado final do cálculo de produção

    API_MRP2-->>Interface: Retorna tempo estimado e detalhes

    Interface-->>Usuario: Exibe os resultados na tela
```

───────── ❖ ─────────

**FLUXO COMPLETO DO SISTEMA**
```mermaid
sequenceDiagram

    participant Usuário

    participant Frontend

    participant Backend

    participant BancoDeDados

  

    %% LOGIN

    Usuário->>Frontend: Insere login e senha

    Frontend->>Backend: Enviar credenciais

    Backend->>BancoDeDados: Validar usuário

    BancoDeDados-->>Backend: Resultado da validação

    Backend-->>Frontend: Sucesso ou falha

    Frontend-->>Usuário: Mensagem de login

  

    %% CONSULTA ESTOQUE

    Usuário->>Frontend: Consultar estoque

    Frontend->>Backend: Requisição de estoque

    Backend->>BancoDeDados: Buscar dados de estoque

    BancoDeDados-->>Backend: Retorna dados

    Backend-->>Frontend: Dados de estoque

    Frontend-->>Usuário: Exibir estoque

  

    %% ENTRADA/SAÍDA DE INSUMOS

    Usuário->>Frontend: Registrar entrada/saída

    Frontend->>Backend: Enviar movimentação

    Backend->>BancoDeDados: Atualizar estoque

    BancoDeDados-->>Backend: Confirmação

    Backend-->>Frontend: Sucesso

    Frontend-->>Usuário: Mostrar resultado

  

    %% VERIFICAÇÃO DE FUNCIONÁRIOS E MÁQUINAS

    Usuário->>Frontend: Verificar funcionário/máquina

    Frontend->>Backend: Requisição de verificação

    Backend->>BancoDeDados: Consultar dados

    BancoDeDados-->>Backend: Retorna dados

    Backend-->>Frontend: Informações

    Frontend-->>Usuário: Exibir dados

  

    %% DEFINIR FUNÇÃO / STATUS

    Usuário->>Frontend: Definir função/status

    Frontend->>Backend: Enviar definição

    Backend->>BancoDeDados: Atualizar dados

    BancoDeDados-->>Backend: Confirmação

    Backend-->>Frontend: Sucesso

    Frontend-->>Usuário: Mostrar confirmação

  

    %% CÁLCULO MRP

    Usuário->>Frontend: Calcular MRP

    Frontend->>Backend: Enviar parâmetros

    Backend->>BancoDeDados: Obter dados necessários

    BancoDeDados-->>Backend: Dados para cálculo

    Backend->>Backend: Calcular necessidades (MRP)

    Backend-->>Frontend: Resultado MRP

    Frontend-->>Usuário: Exibir plano MRP
```

### 5.1.1 Por Requisito Funcional (MRP-I)
**LISTA DE MATERIAIS**
```mermaid

sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant BOMService as "Serviço BOM"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Inserir dados da lista de materiais
    UI ->> Controller: Enviar dados validados
    Controller ->> BOMService: Criar estrutura do produto
    BOMService ->> DB: Salvar produto, componentes e subcomponentes
    DB -->> BOMService: Confirmação de salvamento
    BOMService -->> Controller: Sucesso
    Controller -->> UI: Resposta para o usuário
    UI -->> Usuario: Confirmação de cadastro

```

**ATUALIZAÇÃO DE ESTOQUE**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant EstoqueService as "Serviço de Estoque"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Solicita atualização de estoque
    UI ->> Controller: Enviar dados do item e nova quantidade
    Controller ->> EstoqueService: Atualizar estoque
    EstoqueService ->> DB: Modificar quantidade do item
    DB -->> EstoqueService: Confirmação
    EstoqueService -->> Controller: Estoque atualizado
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Estoque atualizado com sucesso

```

**CONTROLE DE ORDENS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant OrdemService as "Serviço de Ordens"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Criar ou acompanhar ordem
    UI ->> Controller: Enviar dados da ordem ou consulta
    Controller ->> OrdemService: Processar ordem (criar ou consultar)
    OrdemService ->> DB: Gravar/consultar ordem
    DB -->> OrdemService: Resposta
    OrdemService -->> Controller: Resultado da operação
    Controller -->> UI: Resposta para o usuário
    UI -->> Usuario: Confirmação ou status da ordem

```

**PREVISÃO DE DEMANDA**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant DemandaService as "Serviço de Demanda"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Inserir previsão de demanda
    UI ->> Controller: Enviar dados (produto, quantidade, data)
    Controller ->> DemandaService: Registrar previsão
    DemandaService ->> DB: Salvar dados da previsão
    DB -->> DemandaService: Confirmação
    DemandaService -->> Controller: Previsão registrada
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Previsão de demanda cadastrada

```

**CRITÉRIOS DE PRIORIZAÇÃO**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant PrioridadeService as "Serviço de Priorização"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Definir critérios de priorização
    UI ->> Controller: Enviar critérios
    Controller ->> PrioridadeService: Processar regras
    PrioridadeService ->> DB: Salvar ou atualizar regras
    DB -->> PrioridadeService: Confirmação
    PrioridadeService -->> Controller: Critérios registrados
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Critérios de priorização salvos

```

**CALENDÁRIO DE PRODUÇÃO**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant CalendarioService as "Serviço de Calendário"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Configurar calendário de produção
    UI ->> Controller: Enviar dias úteis, feriados, pausas
    Controller ->> CalendarioService: Processar calendário
    CalendarioService ->> DB: Salvar configuração
    DB -->> CalendarioService: Confirmação
    CalendarioService -->> Controller: Calendário salvo
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Calendário configurado com sucesso

```

**CADASTRO DE INSUMOS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant InsumoService as "Serviço de Insumos"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Cadastrar novo insumo
    UI ->> Controller: Enviar dados do insumo
    Controller ->> InsumoService: Registrar insumo
    InsumoService ->> DB: Salvar insumo no banco
    DB -->> InsumoService: Confirmação
    InsumoService -->> Controller: Insumo cadastrado
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Insumo cadastrado com sucesso

```

**CADASTRO DE PRODUTOS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant ProdutoService as "Serviço de Produtos"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Cadastrar novo produto
    UI ->> Controller: Enviar dados do produto
    Controller ->> ProdutoService: Registrar produto
    ProdutoService ->> DB: Salvar informações do produto
    DB -->> ProdutoService: Confirmação
    ProdutoService -->> Controller: Produto cadastrado
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Produto cadastrado com sucesso

```

### 5.1.2 Por Requisito Funcional (MRP-II)
**CADASTRO DE MÁQUINAS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant MaquinaService as "Serviço de Máquinas"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Inserir dados da máquina
    UI ->> Controller: Enviar dados validados
    Controller ->> MaquinaService: Registrar máquina
    MaquinaService ->> DB: Salvar informações
    DB -->> MaquinaService: Confirmação
    MaquinaService -->> Controller: Sucesso
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Máquina cadastrada

```

**CADASTRO DE FUNCIONÁRIOS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant FuncionarioService as "Serviço de Funcionários"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Inserir dados do funcionário
    UI ->> Controller: Enviar informações
    Controller ->> FuncionarioService: Registrar funcionário
    FuncionarioService ->> DB: Salvar informações
    DB -->> FuncionarioService: Confirmação
    FuncionarioService -->> Controller: Sucesso
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Funcionário cadastrado

```

**TEMPO DE MÁQUINA POR PEÇA**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant TempoMaquinaService as "Serviço de Tempo Máquina"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Registrar tempo por peça (máquina)
    UI ->> Controller: Enviar tempo
    Controller ->> TempoMaquinaService: Registrar tempo médio
    TempoMaquinaService ->> DB: Salvar tempo por peça
    DB -->> TempoMaquinaService: Confirmação
    TempoMaquinaService -->> Controller: Tempo registrado
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Tempo de máquina salvo

```

**TEMPO DE FUNCIONÁRIO POR PEÇA**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant TempoFuncionarioService as "Serviço de Tempo Funcionário"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Registrar tempo por peça (funcionário)
    UI ->> Controller: Enviar tempo
    Controller ->> TempoFuncionarioService: Registrar tempo médio
    TempoFuncionarioService ->> DB: Salvar tempo por peça
    DB -->> TempoFuncionarioService: Confirmação
    TempoFuncionarioService -->> Controller: Tempo registrado
    Controller -->> UI: Notificar sucesso
    UI -->> Usuario: Tempo de funcionário salvo

```

**CONTROLE DE CUSTO DAS MÁQUINAS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant CustoMaquinaService as "Serviço de Custo Máquina"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Consultar custos da máquina
    UI ->> Controller: Requisitar dados
    Controller ->> CustoMaquinaService: Calcular custos
    CustoMaquinaService ->> DB: Buscar dados operacionais
    DB -->> CustoMaquinaService: Dados recebidos
    CustoMaquinaService -->> Controller: Custos calculados
    Controller -->> UI: Exibir custos
    UI -->> Usuario: Mostrar análise de custo

```

**CONTROLE DE CUSTOS DOS FUNCIONÁRIOS**
```mermaid
sequenceDiagram
    actor Usuario as "Usuário"
    participant UI as "Interface"
    participant Controller as "Controlador"
    participant CustoFuncionarioService as "Serviço de Custo Funcionário"
    participant DB as "Banco de Dados"

    Usuario ->> UI: Consultar custos da mão de obra
    UI ->> Controller: Requisitar dados
    Controller ->> CustoFuncionarioService: Calcular custos
    CustoFuncionarioService ->> DB: Buscar salários e horas
    DB -->> CustoFuncionarioService: Dados recebidos
    CustoFuncionarioService -->> Controller: Custos calculados
    Controller -->> UI: Exibir custos
    UI -->> Usuario: Mostrar análise de custo

```

## 5.2 Caso de Uso
![UML Diagrama de caso de uso](https://github.com/user-attachments/assets/fa8c3c5a-442b-4560-969f-8a56d5291bc9)


### 5.2.1 Por Requisito Funcional (MRP-I)


### 5.2.2 Por Requisito Funcional (MRP-II)
