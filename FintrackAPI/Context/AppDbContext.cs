using FintrackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FintrackAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<TipoTransacao> TipoTransacoes { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Populando Tipos de Transação
        modelBuilder.Entity<TipoTransacao>().HasData(
            new TipoTransacao { TipoTransacaoId = 1000000001, Nome = "Despesa", Descricao = "Saídas de dinheiro e pagamentos" },
            new TipoTransacao { TipoTransacaoId = 1000000002, Nome = "Receita", Descricao = "Entradas de dinheiro e ganhos" },
            new TipoTransacao { TipoTransacaoId = 1000000003, Nome = "Transferência", Descricao = "Movimentação entre contas" }
        );

        // 2. Populando Categorias
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = 1000000001, Nome = "Alimentação", Descricao = "Supermercado, padaria, restaurantes" },
            new Categoria { CategoriaId = 1000000002, Nome = "Transporte", Descricao = "Ônibus, metrô, combustível, apps de transporte" },
            new Categoria { CategoriaId = 1000000003, Nome = "Salário", Descricao = "Recebimento mensal da empresa" }
        );

        // 3. Populando Transações
        modelBuilder.Entity<Transacao>().HasData(
            new Transacao
            {
                TransacaoId = 1000000001,
                Titulo = "Compra no Supermercado",
                Valor = 350.75m,
                Data = new DateOnly(2026, 3, 5),
                CategoriaId = 1000000001,
                TipoTransacaoId = 1000000001,
                IsCredito = true,
                IsRecorrente = false
            },
            new Transacao
            {
                TransacaoId = 1000000002,
                Titulo = "Pagamento Mensal",
                Valor = 5000.00m,
                Data = new DateOnly(2026, 3, 1),
                CategoriaId = 1000000003,
                TipoTransacaoId = 1000000002,
                IsCredito = false,
                IsRecorrente = true
            }
        );
    }
}
