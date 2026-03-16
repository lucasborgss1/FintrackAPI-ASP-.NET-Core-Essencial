using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FintrackAPI.Context;
using FintrackAPI.Models;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: v1/api/Transacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoes()
        {
            return await _context.Transacoes
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.TipoTransacao)
                .ToListAsync();
        }

        // GET: v1/api/Transacao/{valor}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<Transacao>> GetTransacao(long id)
        {
            var transacao = await _context.Transacoes
                .AsNoTracking()
                .Include(t => t.Categoria)
                .Include(t => t.TipoTransacao)
                .FirstOrDefaultAsync(t => t.TransacaoId == id);

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }

        // PUT: v1/api/Transacao/{valor}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutTransacao(long id, Transacao transacao)
        {
            if (id != transacao.TransacaoId)
            {
                return BadRequest();
            }

            _context.Entry(transacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: v1/api/Transacao
        [HttpPost]
        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
            throw new Exception("Erro lancado");
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacao", new { id = transacao.TransacaoId }, transacao);
        }

        // DELETE: v1/api/Transacao/{valor}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTransacao(long id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacaoExists(long id)
        {
            return _context.Transacoes.Any(e => e.TransacaoId == id);
        }
    }
}
