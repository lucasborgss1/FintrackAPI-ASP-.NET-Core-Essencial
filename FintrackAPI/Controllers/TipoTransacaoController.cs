using Microsoft.AspNetCore.Mvc;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoTransacaoController : ControllerBase
    {
        private readonly ITipoTransacaoRepository _repository;

        public TipoTransacaoController(ITipoTransacaoRepository repository)
        {
            _repository = repository;
        }

        // GET: v1/api/TipoTransacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransacao>>> GetTipoTransacoes()
        {
            var tipoTransacoes = await _repository.GetTipoTransacoesComTransacoesAsync();
            return Ok(tipoTransacoes);
        }

        // GET: v1/api/TipoTransacao/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<TipoTransacao>> GetTipoTransacao(long id)
        {
            var tipoTransacao = await _repository.GetTipoTransacaoComTransacoesAsync(id);

            if (tipoTransacao == null)
            {
                return NotFound();
            }

            return Ok(tipoTransacao);
        }

        // PUT: v1/api/TipoTransacao/{id}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutTipoTransacao(long id, TipoTransacao tipoTransacao)
        {
            if (id != tipoTransacao.TipoTransacaoId)
            {
                return BadRequest();
            }

            _repository.Update(tipoTransacao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // POST: v1/api/TipoTransacao
        [HttpPost]
        public async Task<ActionResult<TipoTransacao>> PostTipoTransacao(TipoTransacao tipoTransacao)
        {
            _repository.Create(tipoTransacao);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetTipoTransacao", new { id = tipoTransacao.TipoTransacaoId }, tipoTransacao);
        }

        // DELETE: v1/api/TipoTransacao/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTipoTransacao(long id)
        {
            var tipoTransacao = await _repository.GetAsync(t => t.TipoTransacaoId == id);

            if (tipoTransacao == null)
            {
                return NotFound();
            }

            _repository.Delete(tipoTransacao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
