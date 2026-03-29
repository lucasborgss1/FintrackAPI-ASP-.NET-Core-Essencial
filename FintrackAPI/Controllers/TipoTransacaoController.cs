using AutoMapper;
using FintrackAPI.DTOs.TipoTransacao;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoTransacaoController(IUnitOfWork ouf, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _ouf = ouf;
        private readonly IMapper _mapper = mapper;

        // GET: v1/api/TipoTransacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransacaoResponseDTO>>> GetTipoTransacoes()
        {
            var tipoTransacoes = await _ouf.TipoTransacaoRepository.GetTipoTransacoesComTransacoesAsync();
            var tipoTransacoesDTO = _mapper.Map<IEnumerable<TipoTransacaoResponseDTO>>(tipoTransacoes);
            return Ok(tipoTransacoesDTO);
        }

        // GET: v1/api/TipoTransacao/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<TipoTransacaoResponseDTO>> GetTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetTipoTransacaoComTransacoesAsync(id);

            if (tipoTransacao == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Tipo de transação não encontrado.",
                    Detail = $"Nenhum tipo de transação não encontrado com o id {id}.",
                    Instance = HttpContext.Request.Path
                });
            }


            var tipoTransacaoDTO = _mapper.Map<TipoTransacaoResponseDTO>(tipoTransacao);
            return Ok(tipoTransacaoDTO);
        }

        // PUT: v1/api/TipoTransacao/{id}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutTipoTransacao(long id, TipoTransacaoRequestDTO tipoTransacaoDTO)
        {
            var tipoTransacao = _mapper.Map<TipoTransacao>(tipoTransacaoDTO);
            tipoTransacao.TipoTransacaoId = id;

            _ouf.TipoTransacaoRepository.Update(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }

        // POST: v1/api/TipoTransacao
        [HttpPost]
        public async Task<ActionResult<TipoTransacaoResponseDTO>> PostTipoTransacao(TipoTransacaoRequestDTO tipoTransacaoDTO)
        {
            var tipoTransacao = _mapper.Map<TipoTransacao>(tipoTransacaoDTO);
            var tipoTransacaoCriado = _ouf.TipoTransacaoRepository.Create(tipoTransacao);
            await _ouf.Commit();

            var tipoTransacaoResponse = _mapper.Map<TipoTransacaoResponseDTO>(tipoTransacaoCriado);
            return CreatedAtAction("GetTipoTransacao", new { id = tipoTransacaoCriado.TipoTransacaoId }, tipoTransacaoResponse);
        }

        // DELETE: v1/api/TipoTransacao/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetAsync(t => t.TipoTransacaoId == id);

            if (tipoTransacao == null)
            {
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Tipo de transação não encontrado.",
                    Detail = $"Nenhum tipo de transação não encontrado com o id {id}.",
                    Instance = HttpContext.Request.Path
                });
            }

            _ouf.TipoTransacaoRepository.Delete(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }
    }
}
