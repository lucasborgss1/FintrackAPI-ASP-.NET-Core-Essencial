using AutoMapper;
using FintrackAPI.DTOs.Transacao;
using FintrackAPI.Models;
using FintrackAPI.Pagination;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    /// <summary>
    /// Gerenciamento de transações financeiras
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TransacaoController(IUnitOfWork ouf, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _ouf = ouf;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retorna todas as transações paginadas
        /// </summary>
        /// <param name="transacaoParams">Parâmetros de paginação</param>
        /// <response code="200">Lista retornada com sucesso. Metadados no header X-Pagination</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransacaoResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransacaoResponseDTO>>> GetTransacoes([FromQuery] TransacaoParameters transacaoParams)
        {
            var transacoes = await _ouf.TransacaoRepository.GetAllAsync(transacaoParams);

            var metadata = new
            {
                transacoes.TotalCount,
                transacoes.PageSize,
                transacoes.CurrentPage,
                transacoes.TotalPages,
                transacoes.HasNext,
                transacoes.HasPrevious
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));

            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoResponseDTO>>(transacoes);
            return Ok(transacoesDTO);
        }

        /// <summary>
        /// Retorna transações filtradas por data com paginação
        /// </summary>
        /// <param name="transacaoFiltroData">Filtro de data e parâmetros de paginação</param>
        /// <response code="200">Lista filtrada retornada com sucesso. Metadados no header X-Pagination</response>
        [HttpGet("filtro/data")]
        [ProducesResponseType(typeof(IEnumerable<TransacaoResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransacaoResponseDTO>>> GetTransacoesFiltroData([FromQuery] TransacaoDataParameters transacaoFiltroData)
        {
            var transacoes = await _ouf.TransacaoRepository.GetTransacoesFiltroData(transacaoFiltroData);

            var metadata = new
            {
                transacoes.TotalCount,
                transacoes.PageSize,
                transacoes.CurrentPage,
                transacoes.TotalPages,
                transacoes.HasNext,
                transacoes.HasPrevious
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));

            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoResponseDTO>>(transacoes);
            return Ok(transacoesDTO);
        }

        /// <summary>
        /// Retorna uma transação pelo ID
        /// </summary>
        /// <param name="id">ID da transação (10 dígitos, mínimo 1000000001)</param>
        /// <response code="200">Transação encontrada</response>
        /// <response code="404">Transação não encontrada</response>
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(typeof(TransacaoResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransacaoResponseDTO>> GetTransacao(long id)
        {
            var transacao = await _ouf.TransacaoRepository.GetTransacaoComRelacionamentosAsync(id);

            if (transacao == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Transação não encontrada.",
                    Detail = $"Nenhuma transação encontrada com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            var transacaoDTO = _mapper.Map<TransacaoResponseDTO>(transacao);
            return Ok(transacaoDTO);
        }

        /// <summary>
        /// Atualiza uma transação existente
        /// </summary>
        /// <param name="id">ID da transação a ser atualizada</param>
        /// <param name="transacaoDTO">Dados atualizados da transação</param>
        /// <response code="204">Transação atualizada com sucesso</response>
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutTransacao(long id, TransacaoRequestDTO transacaoDTO)
        {
            var transacao = _mapper.Map<Transacao>(transacaoDTO);
            transacao.TransacaoId = id;

            _ouf.TransacaoRepository.Update(transacao);
            await _ouf.Commit();

            return NoContent();
        }

        /// <summary>
        /// Cria uma nova transação
        /// </summary>
        /// <param name="transacaoDTO">Dados da nova transação</param>
        /// <response code="201">Transação criada com sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(TransacaoResponseDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<TransacaoResponseDTO>> PostTransacao(TransacaoRequestDTO transacaoDTO)
        {
            var transacao = _mapper.Map<Transacao>(transacaoDTO);
            _ouf.TransacaoRepository.Create(transacao);
            await _ouf.Commit();

            var transacaoCriada = await _ouf.TransacaoRepository.GetTransacaoComRelacionamentosAsync(transacao.TransacaoId);
            var transacaoResponse = _mapper.Map<TransacaoResponseDTO>(transacaoCriada);
            return CreatedAtAction("GetTransacao", new { id = transacaoCriada!.TransacaoId }, transacaoResponse);
        }

        /// <summary>
        /// Remove uma transação pelo ID
        /// </summary>
        /// <param name="id">ID da transação a ser removida</param>
        /// <response code="204">Transação removida com sucesso</response>
        /// <response code="404">Transação não encontrada</response>
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTransacao(long id)
        {
            var transacao = await _ouf.TransacaoRepository.GetAsync(t => t.TransacaoId == id);

            if (transacao == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Transação não encontrada.",
                    Detail = $"Nenhuma transação encontrada com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            _ouf.TransacaoRepository.Delete(transacao);
            await _ouf.Commit();

            return NoContent();
        }
    }
}