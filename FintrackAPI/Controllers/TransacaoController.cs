using Microsoft.AspNetCore.Mvc;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository _repository;

        public TransacaoController(ITransacaoRepository repository)
        {
            _repository = repository;
        }

        // GET: v1/api/Transacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoes()
        {
            var transacoes = await _repository.GetTransacoesComRelacionamentosAsync();
            return Ok(transacoes);
        }

        // GET: v1/api/Transacao/{valor}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<Transacao>> GetTransacao(long id)
        {
            var transacao = await _repository.GetTransacaoComRelacionamentosAsync(id);

            if (transacao == null)
            {
                return NotFound();
            }

            return Ok(transacao);
        }

        // PUT: v1/api/Transacao/{valor}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutTransacao(long id, Transacao transacao)
        {
            if (id != transacao.TransacaoId)
            {
                return BadRequest();
            }

           _repository.Update(transacao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // POST: v1/api/Transacao
        [HttpPost]
        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
            var transacaoCriada = _repository.Create(transacao);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetTransacao", new { id = transacaoCriada.TransacaoId }, transacaoCriada);
        }

        // DELETE: v1/api/Transacao/{valor}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTransacao(long id)
        {
            var transacao = await _repository.GetAsync(t => t.TransacaoId == id);

            if (transacao == null)
            {
                return NotFound();
            }

            _repository.Delete(transacao);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
