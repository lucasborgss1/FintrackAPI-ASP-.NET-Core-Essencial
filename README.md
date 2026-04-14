# FintrackAPI

API REST para controle financeiro pessoal desenvolvida com **ASP.NET Core 8** e **Entity Framework Core**, utilizando **MySQL** como banco de dados relacional.

---

## 📋 Sumário

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Modelos de Dados](#modelos-de-dados)
- [Configuração e Execução](#configuração-e-execução)
- [Migrations](#migrations)
- [Documentação da API](#documentação-da-api)

---

## Sobre o Projeto

O **FintrackAPI** é uma API REST voltada ao gerenciamento de finanças pessoais. Ela permite o cadastro e consulta de transações financeiras (receitas, despesas e transferências), organizadas por categorias e tipos de transação.

---

## Tecnologias

| Tecnologia | Versão |
|---|---|
| .NET / ASP.NET Core | 8.0 |
| Entity Framework Core | 8.0.24 |
| Pomelo.EntityFrameworkCore.MySql | 8.0.2 |
| Swashbuckle.AspNetCore (Swagger) | 6.6.2 |
| MySQL | — |

---

## Estrutura do Projeto

```
FintrackAPI/
├── Context/
│   └── AppDbContext.cs        # DbContext com seed de dados iniciais
├── Controllers/               # Controllers da API (a implementar)
├── Migrations/                # Histórico de migrações do banco de dados
├── Models/
│   ├── Categoria.cs           # Modelo de categoria financeira
│   ├── TipoTransacao.cs       # Modelo de tipo de transação
│   └── Transacao.cs           # Modelo de transação financeira
├── Properties/
│   └── launchSettings.json    # Configurações de execução local
├── Program.cs                 # Ponto de entrada e configuração dos serviços
└── FintrackAPI.csproj
```

---

## Modelos de Dados

### Categoria (`CAT_categoria`)

Agrupa transações por tema (ex.: Alimentação, Transporte).

| Campo | Tipo | Obrigatório | Descrição |
|---|---|---|---|
| `CategoriaId` | `int` | ✅ | Identificador único |
| `Nome` | `string (50)` | ✅ | Nome da categoria |
| `Descricao` | `string (150)` | ❌ | Descrição da categoria |

---

### TipoTransacao (`TPT_tipo_transacao`)

Define o tipo da movimentação financeira.

| Campo | Tipo | Obrigatório | Descrição |
|---|---|---|---|
| `TipoTransacaoId` | `int` | ✅ | Identificador único |
| `Nome` | `string (50)` | ✅ | Nome do tipo |
| `Descricao` | `string (150)` | ❌ | Descrição do tipo |

**Tipos pré-cadastrados:**

| Id | Nome | Descrição |
|---|---|---|
| 1000000001 | Despesa | Saídas de dinheiro e pagamentos |
| 1000000002 | Receita | Entradas de dinheiro e ganhos |
| 1000000003 | Transferência | Movimentação entre contas |

---

### Transacao (`TRA_transacao`)

Representa uma movimentação financeira.

| Campo | Tipo | Obrigatório | Descrição |
|---|---|---|---|
| `TransacaoId` | `int` | ✅ | Identificador único |
| `Titulo` | `string (100)` | ✅ | Título da transação |
| `Valor` | `decimal (18,2)` | ✅ | Valor da transação |
| `Data` | `DateOnly` | ✅ | Data da transação |
| `CategoriaId` | `int` | ✅ | FK para Categoria |
| `TipoTransacaoId` | `int` | ✅ | FK para TipoTransacao |
| `IsCredito` | `bool` | ✅ | Indica se é um lançamento a crédito |
| `IsRecorrente` | `bool` | ✅ | Indica se a transação é recorrente |

---

## Configuração e Execução

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL Server em execução

### Configuração da String de Conexão

Edite o arquivo `appsettings.json` (ou `appsettings.Development.json`) adicionando a string de conexão com o seu banco MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=fintrack;user=root;password=sua_senha"
  }
}
```

### Executando a aplicação

```bash
# Restaurar dependências
dotnet restore

# Aplicar as migrations no banco de dados
dotnet ef database update

# Iniciar a aplicação
dotnet run --project FintrackAPI
```

A API estará disponível em:
- HTTP: `http://localhost:5082`
- HTTPS: `https://localhost:7142`

---

## Migrations

As migrations são gerenciadas pelo Entity Framework Core. Para criar uma nova migration após alterar os modelos:

```bash
dotnet ef migrations add NomeDaMigracao --project FintrackAPI
```

Para aplicar as migrations pendentes:

```bash
dotnet ef database update --project FintrackAPI
```

**Histórico de migrations:**

| Migration | Descrição |
|---|---|
| `20260308193410_MigracaoInicial` | Criação inicial das tabelas |
| `20260308211455_AjusteTabelas` | Ajustes nas tabelas |
| `20260308215115_PopulaBancoInicial` | Seed de dados iniciais |
| `20260308220417_AjusteTabelaTransacao` | Ajuste na tabela de transações |

---

## Documentação da API

Em ambiente de desenvolvimento, a documentação interativa via **Swagger UI** está disponível em:

```
http://localhost:5082/swagger
```

ou

```
https://localhost:7142/swagger
```