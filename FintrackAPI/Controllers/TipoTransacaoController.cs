using AutoMapper;
using FintrackAPI.DTOs.TipoTransacao;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    /// <summary>
    /// Gerenciamento de tipos de transação (Despesa, Receita, Transferência)
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoTransacaoController(IUnitOfWork ouf, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _ouf = ouf;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retorna todos os tipos de transação com suas transações associadas
        /// </summary>
        /// <response code="200">Lista de tipos de transação retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TipoTransacaoResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoTransacaoResponseDTO>>> GetTipoTransacoes()
        {
            var tipoTransacoes = await _ouf.TipoTransacaoRepository.GetTipoTransacoesComTransacoesAsync();
            var tipoTransacoesDTO = _mapper.Map<IEnumerable<TipoTransacaoResponseDTO>>(tipoTransacoes);
            return Ok(tipoTransacoesDTO);
        }

        /// <summary>
        /// Retorna um tipo de transação pelo ID
        /// </summary>
        /// <param name="id">ID do tipo de transação (10 dígitos, mínimo 1000000001)</param>
        /// <response code="200">Tipo de transação encontrado</response>
        /// <response code="404">Tipo de transação não encontrado</response>
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(typeof(TipoTransacaoResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoTransacaoResponseDTO>> GetTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetTipoTransacaoComTransacoesAsync(id);

            if (tipoTransacao == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Tipo de transação não encontrado.",
                    Detail = $"Nenhum tipo de transação encontrado com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            var tipoTransacaoDTO = _mapper.Map<TipoTransacaoResponseDTO>(tipoTransacao);
            return Ok(tipoTransacaoDTO);
        }

        /// <summary>
        /// Atualiza um tipo de transação existente
        /// </summary>
        /// <param name="id">ID do tipo de transação a ser atualizado</param>
        /// <param name="tipoTransacaoDTO">Dados atualizados do tipo de transação</param>
        /// <response code="204">Tipo de transação atualizado com sucesso</response>
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutTipoTransacao(long id, TipoTransacaoRequestDTO tipoTransacaoDTO)
        {
            var tipoTransacao = _mapper.Map<TipoTransacao>(tipoTransacaoDTO);
            tipoTransacao.TipoTransacaoId = id;

            _ouf.TipoTransacaoRepository.Update(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }

        /// <summary>
        /// Cria um novo tipo de transação
        /// </summary>
        /// <param name="tipoTransacaoDTO">Dados do novo tipo de transação</param>
        /// <response code="201">Tipo de transação criado com sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(TipoTransacaoResponseDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<TipoTransacaoResponseDTO>> PostTipoTransacao(TipoTransacaoRequestDTO tipoTransacaoDTO)
        {
            var tipoTransacao = _mapper.Map<TipoTransacao>(tipoTransacaoDTO);
            var tipoTransacaoCriado = _ouf.TipoTransacaoRepository.Create(tipoTransacao);
            await _ouf.Commit();

            var tipoTransacaoResponse = _mapper.Map<TipoTransacaoResponseDTO>(tipoTransacaoCriado);
            return CreatedAtAction("GetTipoTransacao", new { id = tipoTransacaoCriado.TipoTransacaoId }, tipoTransacaoResponse);
        }

        /// <summary>
        /// Remove um tipo de transação pelo ID
        /// </summary>
        /// <param name="id">ID do tipo de transação a ser removido</param>
        /// <response code="204">Tipo de transação removido com sucesso</response>
        /// <response code="404">Tipo de transação não encontrado</response>
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTipoTransacao(long id)
        {
            var tipoTransacao = await _ouf.TipoTransacaoRepository.GetAsync(t => t.TipoTransacaoId == id);

            if (tipoTransacao == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Tipo de transação não encontrado.",
                    Detail = $"Nenhum tipo de transação encontrado com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            _ouf.TipoTransacaoRepository.Delete(tipoTransacao);
            await _ouf.Commit();

            return NoContent();
        }
    }
}
