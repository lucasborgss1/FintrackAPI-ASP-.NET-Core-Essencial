using Microsoft.AspNetCore.Mvc;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoTransacaoController : ControllerBase
    {
        private readonly IUnitOfWork _ouf;

        public TipoTransacaoController(IUnitOfWork ouf)
        {
            _ouf = ouf;
        }

        // GET: v1/api/TipoTransacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransacao>>> GetTipoTransacoes()
        {
            var tipoTransacoes = await _ouf.TipoTransacaoRepository.GetTipoTransacoesComTransacoesAsync();
            return Ok(tipoTransacoes);
        }

        // GET: v1/api/TipoTransacao/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<TipoTransacao>> GetTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetTipoTransacaoComTransacoesAsync(id);

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

            _ouf.TipoTransacaoRepository.Update(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }

        // POST: v1/api/TipoTransacao
        [HttpPost]
        public async Task<ActionResult<TipoTransacao>> PostTipoTransacao(TipoTransacao tipoTransacao)
        {
            var tipoTransacaoCriado = _ouf.TipoTransacaoRepository.Create(tipoTransacao);
            await _ouf.Commit();

            return CreatedAtAction("GetTipoTransacao", new { id = tipoTransacaoCriado.TipoTransacaoId }, tipoTransacaoCriado);
        }

        // DELETE: v1/api/TipoTransacao/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetAsync(t => t.TipoTransacaoId == id);

            if (tipoTransacao == null)
            {
                return NotFound();
            }

            _ouf.TipoTransacaoRepository.Delete(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }
    }
}
