using AutoMapper;
using FintrackAPI.DTOs.Transacao;
using FintrackAPI.Models;
using FintrackAPI.Pagination;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TransacaoController(IUnitOfWork ouf, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _ouf = ouf;
        private readonly IMapper _mapper = mapper;

        // GET: v1/api/Transacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoResponseDTO>>> GetTransacoes()
        {
            var transacoes = await _ouf.TransacaoRepository.GetTransacoesComRelacionamentosAsync();
            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoResponseDTO>>(transacoes);
            return Ok(transacoesDTO);
        }

        // GET: v1/api/Transacao/pagination
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<TransacaoResponseDTO>>> GetTransacoes([FromQuery] TransacaoParameters transacaoParameters)
        {
            var transacoes = await _ouf.TransacaoRepository.GetAllAsync(transacaoParameters);
            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoResponseDTO>>(transacoes);
            return Ok(transacoesDTO);
        }

        // GET: v1/api/Transacao/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<TransacaoResponseDTO>> GetTransacao(long id)
        {
            var transacao = await _ouf.TransacaoRepository.GetTransacaoComRelacionamentosAsync(id);

            if (transacao == null)
            {
                return NotFound();
            }

            var transacaoDTO = _mapper.Map<TransacaoResponseDTO>(transacao);
            return Ok(transacaoDTO);
        }

        // PUT: v1/api/Transacao/{id}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutTransacao(long id, TransacaoRequestDTO transacaoDTO)
        {
            var transacao = _mapper.Map<Transacao>(transacaoDTO);
            transacao.TransacaoId = id;

            _ouf.TransacaoRepository.Update(transacao);
            await _ouf.Commit();

            return NoContent();
        }

        // POST: v1/api/Transacao
        [HttpPost]
        public async Task<ActionResult<TransacaoResponseDTO>> PostTransacao(TransacaoRequestDTO transacaoDTO)
        {
            var transacao = _mapper.Map<Transacao>(transacaoDTO);
            _ouf.TransacaoRepository.Create(transacao);
            await _ouf.Commit();

            var transacaoCriada = await _ouf.TransacaoRepository.GetTransacaoComRelacionamentosAsync(transacao.TransacaoId);
            var transacaoResponse = _mapper.Map<TransacaoResponseDTO>(transacaoCriada);
            return CreatedAtAction("GetTransacao", new { id = transacaoCriada!.TransacaoId }, transacaoResponse);
        }

        // DELETE: v1/api/Transacao/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTransacao(long id)
        {
            var transacao = await _ouf.TransacaoRepository.GetAsync(t => t.TransacaoId == id);

            if (transacao == null)
            {
                return NotFound();
            }

            _ouf.TransacaoRepository.Delete(transacao);
            await _ouf.Commit();

            return NoContent();
        }
    }
}