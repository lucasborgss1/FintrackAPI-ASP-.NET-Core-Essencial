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
}
