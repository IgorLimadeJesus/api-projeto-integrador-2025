## 1. Introdução

Este projeto é uma API RESTful desenvolvida em ASP.NET Core, com foco na gestão de recursos de produção (MRP-I e MRP-II). Ela oferece endpoints para gerenciar funcionários, insumos, produtos e movimentações de estoque.

## 2. Especificações Técnicas

- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Estrutura de Projeto:** Solução `.sln` com o projeto principal localizado na pasta `mrp-api`
- **Padrões Adotados:**
  - Arquitetura em camadas
  - Separação de responsabilidades (Controllers, Services, Repositories)
  - Uso de Entity Framework Core para acesso a dados
- **Banco de Dados:** SQL Server (padrão), com possibilidade de adaptação para outros SGBDs

## 3. Instalação do .NET SDK no Linux

Para executar ou desenvolver esta aplicação em ambientes Linux, é necessário instalar o .NET SDK. Abaixo estão as instruções para distribuições baseadas em Debian/Ubuntu.

### 3.1. Instalando o .NET SDK 8.0 no Ubuntu

```bash
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update
sudo apt install dotnet-sdk-8.0
```

**Nota:** Caso deseje instalar uma versão diferente do SDK, substitua `8.0` pela versão desejada. Consulte a [documentação oficial](https://learn.microsoft.com/pt-br/dotnet/core/install/linux-ubuntu) para mais detalhes.

### 3.2. Verificando a Instalação

`dotnet --version`

A saída deve exibir a versão instalada do SDK.

## 4. Clonando e Executando o Projeto

### 4.1. Clonando o Repositório

`git clone https://github.com/IgorLimadeJesus/api-projeto-integrador-2025.git cd api-projeto-integrador-2025`

### 4.2. Restaurando Dependências

`dotnet restore`

### 4.3. Executando a Aplicação

`dotnet run --project mrp-api`

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`, dependendo da configuração.

## 5. Utilizando a API

### 5.1. Endpoints Disponíveis

#### Funcionários

- `GET /api/funcionarios`
    
- `GET /api/funcionarios/{id}`
    
- `POST /api/funcionarios`
    
- `PUT /api/funcionarios/{id}`
    
- `DELETE /api/funcionarios/{id}`
    

#### Estoque de Insumos

- `GET /api/estoqueinsumo`
    
- `POST /api/estoqueinsumo`
    

#### Estoque de Produtos

- `GET /api/estoqueproduto`
    
- `POST /api/estoqueproduto`
    

#### Entradas de Insumos

- `POST /api/entradainsumo`
    

#### Saídas de Produtos

- `POST /api/saidaproduto`
    

#### Saídas de Insumos

- `POST /api/saidainsumo`
    

### 5.2. Testando com o Swagger

A aplicação inclui o Swagger para facilitar o teste dos endpoints. Após iniciar a aplicação, acesse:

- `https://localhost:5001/swagger`
    
- ou `http://localhost:5000/swagger`
    

O Swagger UI permitirá testar os endpoints diretamente pelo navegador.

## 6. Configuração do Banco de Dados

Por padrão, a aplicação está configurada para utilizar o SQL Server. Certifique-se de que o SQL Server esteja instalado e em execução em sua máquina. As configurações de conexão podem ser ajustadas no arquivo `appsettings.json` localizado na pasta `mrp-api`.

### Exemplo de configuração:

`{   "ConnectionStrings": {     "DefaultConnection": "Server=localhost;Database=MrpDb;User Id=seu_usuario;Password=sua_senha;"   } }`

 **Nota:** Substitua `seu_usuario` e `sua_senha` pelas credenciais do seu banco de dados.
