CREATE DATABASE MRPIII;
GO

USE MRPIII;

GO

CREATE TABLE Setor (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Cargo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Funcionario (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    ID_Cargo INT NOT NULL,
    ID_Setor INT NOT NULL,
    Hierarquia INT NOT NULL,
    Status_ INT NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    Matricula INT NOT NULL CHECK (Matricula BETWEEN 0 AND 99999),
    ID_Maquina INT NULL,
    Senha VARCHAR(20) NOT NULL,
    FOREIGN KEY (ID_Cargo) REFERENCES Cargo(ID),
    FOREIGN KEY (ID_Setor) REFERENCES Setor(ID)
);

CREATE TABLE Maquina (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    Modelo VARCHAR(100) NOT NULL,
    Status BIT NOT NULL,
    ID_Funcionario INT NULL,
    Codigo VARCHAR(50) NOT NULL,
    Custo_Por_Hora DECIMAL(10,2) NOT NULL,
    Previsao_Manutencao DATE NULL,
    FOREIGN KEY (ID_Funcionario) REFERENCES Funcionario(ID)
);

ALTER TABLE Funcionario
ADD CONSTRAINT ID_Maquina FOREIGN KEY (ID_Maquina) REFERENCES Maquina(ID);

CREATE TABLE Produto (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Tipo VARCHAR(25) NOT NULL,
    Codigo VARCHAR(50) NOT NULL,
    ID_Maquina INT NULL,
    ID_Funcionario INT NULL,
    Qntd INT NOT NULL,
    Custo DECIMAL(10,2) NOT NULL,
	FOREIGN KEY (ID_Maquina) REFERENCES Maquina(ID),
    FOREIGN KEY (ID_Funcionario) REFERENCES Funcionario(ID)
);

CREATE TABLE Cliente (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Contato VARCHAR(100),
    CPF_CNPJ VARCHAR(14) NOT NULL,
	CEP VARCHAR(10) NOT NULL,
    Rua VARCHAR(100) NOT NULL,
    Bairro VARCHAR(100) NOT NULL,
    Numero INT NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Complemento VARCHAR(50) NULL,
    Pais VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL
);

CREATE TABLE Fornecedor (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Contato VARCHAR(100),
    CPF_CNPJ VARCHAR(14) NOT NULL,
	CEP VARCHAR(10) NOT NULL,
    Rua VARCHAR(100) NOT NULL,
    Bairro VARCHAR(100) NOT NULL,
    Numero INT NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Complemento VARCHAR(50) NULL,
    Pais VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL
);

CREATE TABLE Transportador (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Contato VARCHAR(100),
    CPF_CNPJ VARCHAR(14) NOT NULL,
	CEP VARCHAR(10) NOT NULL,
    Rua VARCHAR(100) NOT NULL,
    Bairro VARCHAR(100) NOT NULL,
    Numero INT NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Complemento VARCHAR(50) NULL,
    Pais VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL
);

CREATE TABLE Insumo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
	Tipo VARCHAR(50) NOT NULL,
	Codigo VARCHAR (50) NOT NULL,
    Custo DECIMAL(10,2) NOT NULL,
    ID_Fornecedor INT NOT NULL,
    FOREIGN KEY (ID_Fornecedor) REFERENCES Fornecedor(ID)
);

CREATE TABLE Venda (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Cliente INT NOT NULL,
    Codigo VARCHAR(50) NOT NULL,
	Data_Compra DATETIME NOT NULL,
    Data_Entrada DATETIME NOT NULL,
    Status_ INT NOT NULL CHECK (Status_ BETWEEN 0 AND 9),
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID)
);

CREATE TABLE ListaProduto (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    ID_Insumo INT NOT NULL,
    Qntd INT NOT NULL,
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID),
    FOREIGN KEY (ID_Insumo) REFERENCES Insumo(ID)
);

CREATE TABLE Compra (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Fornecedor INT NOT NULL,
    Codigo VARCHAR(10) NOT NULL,
    Data_Compra DATETIME NOT NULL,
    Status INT NOT NULL,
    Valor_Total DECIMAL(10,2) NOT NULL,
    ID_Transportador INT NULL,
    FOREIGN KEY (ID_Fornecedor) REFERENCES Fornecedor(ID),
    FOREIGN KEY (ID_Transportador) REFERENCES Transportador(ID)
);

CREATE TABLE Producao (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    Codigo VARCHAR (50) NOT NULL,
    Data_Producao DATETIME NOT NULL,
    Qntd INT NOT NULL,
    Custo_Total DECIMAL(10,2),
    Status INT NOT NULL,
    ID_Setor INT NOT NULL,
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID),
	FOREIGN KEY (ID_Setor) REFERENCES Setor(ID)
);

CREATE TABLE ListaInsumo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Compra INT NOT NULL,
    ID_Insumo INT NOT NULL,
    Qntd INT NULL,
    FOREIGN KEY (ID_Compra) REFERENCES Compra(ID),
    FOREIGN KEY (ID_Insumo) REFERENCES Insumo(ID)
);

CREATE TABLE MovimentacaoInsumo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Insumo INT NOT NULL,
    ID_Compra INT NULL,
    ID_Producao INT NULL,
    Codigo VARCHAR(50) NOT NULL,
    Qntd INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    Data_Movimentacao DATETIME NOT NULL,
    Tipo_Movimentacao BIT NOT NULL,
    FOREIGN KEY (ID_Insumo) REFERENCES Insumo(ID),
    FOREIGN KEY (ID_Compra) REFERENCES Compra(ID),
    FOREIGN KEY (ID_Producao) REFERENCES Producao(ID)
);

CREATE TABLE MovimentacaoProduto (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    ID_Venda INT NULL,
    ID_Producao INT NULL,
    Codigo VARCHAR(50) NOT NULL,
    Qntd INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    Data_Movimentacao DATETIME NOT NULL,
    Tipo_Movimentacao BIT NOT NULL,
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID),
    FOREIGN KEY (ID_Venda) REFERENCES Venda(ID),
    FOREIGN KEY (ID_Producao) REFERENCES Producao(ID)
);

CREATE TABLE EstoqueInsumo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Insumo INT NOT NULL,
    Qntd INT NOT NULL,
    Qntd_Minima INT NOT NULL,
    FOREIGN KEY (ID_Insumo) REFERENCES Insumo(ID)
);

CREATE TABLE ListaVenda (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Venda INT NOT NULL,
    ID_Produto INT NOT NULL,
    Qntd INT NOT NULL,
    FOREIGN KEY (ID_Venda) REFERENCES Venda(ID),
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID)
);

CREATE TABLE CustoInsumo (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Insumo INT NOT NULL,
    Qntd INT NOT NULL,
    Custo_Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Insumo) REFERENCES Insumo(ID)
);

CREATE TABLE TempoProducao (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    ID_Maquina INT NOT NULL,
    ID_Funcionario INT NOT NULL,
    Data_Uso_Maquina DATETIME NOT NULL,
    Data_Uso_Funcionario DATETIME NOT NULL,
    Temp_Maquina INT NOT NULL,
    Temp_Funcionario INT NOT NULL,
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID),
    FOREIGN KEY (ID_Maquina) REFERENCES Maquina(ID),
    FOREIGN KEY (ID_Funcionario) REFERENCES Funcionario(ID)
);

CREATE TABLE CustoMaquina (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Maquina INT NOT NULL,
    ID_TempoProducao INT NOT NULL,
    Custo_Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Maquina) REFERENCES Maquina(ID),
    FOREIGN KEY (ID_TempoProducao) REFERENCES TempoProducao(ID)
);

CREATE TABLE CustoFuncionario (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Funcionario INT NOT NULL,
    ID_TempoProducao INT NOT NULL,
    Custo_Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Funcionario) REFERENCES Funcionario(ID),
    FOREIGN KEY (ID_TempoProducao) REFERENCES TempoProducao(ID)
);

	CREATE TABLE CustoProduto (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    ID_Custo_Maquina INT NOT NULL,
    ID_Custo_Funcionario INT NOT NULL,
    ID_Custo_Insumo INT NOT NULL,
    Custo_Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID),
    FOREIGN KEY (ID_Custo_Maquina) REFERENCES CustoMaquina(ID),
    FOREIGN KEY (ID_Custo_Funcionario) REFERENCES CustoFuncionario(ID),
    FOREIGN KEY (ID_Custo_Insumo) REFERENCES CustoInsumo(ID)
);

CREATE TABLE Lucratividade (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Periodo DATETIME NOT NULL,
    ID_Funcionario INT NULL,
    ID_Maquina INT NULL,
    ID_Produto INT NOT NULL,
    ID_CustoProduto INT NOT NULL,
    Valor_Venda DECIMAL(10,2) NOT NULL,
    Lucro DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Funcionario) REFERENCES Funcionario(ID),
    FOREIGN KEY (ID_Maquina) REFERENCES Maquina(ID),
    FOREIGN KEY (ID_Produto) REFERENCES Produto(ID)
);

CREATE TABLE Usuarios(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(100) not null,
	Email nvarchar(100) not null,
	Senha nvarchar(255) not null
);



--Atualização 24_05 - Alterar a tabela Producao para OrdemProducao

-- Renomear a tabela Producao para OrdemProducao
EXEC sp_rename 'Producao', 'OrdemProducao';

-- Remover a foreign key da coluna ID_Setor (impede a exclusão da coluna)
ALTER TABLE OrdemProducao
DROP CONSTRAINT FK__Producao__ID_Set__5CD6CB2B;

-- Remover colunas que não fazem mais parte da estrutura nova
ALTER TABLE OrdemProducao DROP COLUMN Custo_Total;
ALTER TABLE OrdemProducao DROP COLUMN ID_Setor;
ALTER TABLE OrdemProducao DROP COLUMN Data_Producao;

-- Adicionar as novas colunas
ALTER TABLE OrdemProducao ADD 
    Data_Criacao DATETIME NOT NULL DEFAULT GETDATE(),
    Data_Entrega_Esperada DATETIME NOT NULL;

-- Garantir que a coluna Status seja NOT NULL
ALTER TABLE OrdemProducao
ALTER COLUMN Status INT NOT NULL;

-- Adicionar constraint CHECK para valores válidos de Status
ALTER TABLE OrdemProducao
ADD CONSTRAINT CK_Status_OrdemProducao CHECK (Status IN (0, 1, 2));

--Atualização 31_05 - Adicionar Excluir a coluna "Senha" da tabela funcionário
ALTER TABLE Funcionario
DROP COLUMN Senha;