using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FintrackAPI.Context;
using FintrackAPI.Models;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoTransacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoTransacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: v1/api/TipoTransacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransacao>>> GetTipoTransacoes()
        {
            return await _context.TipoTransacoes
                .Include(t => t.Transacoes)
                .ToListAsync();
        }

        // GET: v1/api/TipoTransacao/{valor}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoTransacao>> GetTipoTransacao(int id)
        {
            var tipoTransacao = await _context.TipoTransacoes
                .Include(t => t.Transacoes)
                .FirstOrDefaultAsync(t => t.TipoTransacaoId == id);

            if (tipoTransacao == null)
            {
                return NotFound();
            }

            return tipoTransacao;
        }

        // PUT: v1/api/TipoTransacao/{valor}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTipoTransacao(int id, TipoTransacao tipoTransacao)
        {
            if (id != tipoTransacao.TipoTransacaoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoTransacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTransacaoExists(id))
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

        // POST: v1/api/TipoTransacao
        [HttpPost]
        public async Task<ActionResult<TipoTransacao>> PostTipoTransacao(TipoTransacao tipoTransacao)
        {
            _context.TipoTransacoes.Add(tipoTransacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTransacao", new { id = tipoTransacao.TipoTransacaoId }, tipoTransacao);
        }

        // DELETE: v1/api/TipoTransacao/{valor}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTipoTransacao(int id)
        {
            var tipoTransacao = await _context.TipoTransacoes.FindAsync(id);
            if (tipoTransacao == null)
            {
                return NotFound();
            }

            _context.TipoTransacoes.Remove(tipoTransacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTransacaoExists(int id)
        {
            return _context.TipoTransacoes.Any(e => e.TipoTransacaoId == id);
        }
    }
}
