using AutoMapper;
using FintrackAPI.DTOs.Categoria;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    /// <summary>
    /// Gerenciamento de categorias de transações
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriaController(IUnitOfWork uof, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _uof = uof;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retorna todas as categorias com suas transações associadas
        /// </summary>
        /// <response code="200">Lista de categorias retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoriaResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDTO>>> GetCategorias()
        {
            var categorias = await _uof.CategoriaRepository.GetCategoriasComTransacoesAsync();
            var categoriasDTO = _mapper.Map<IEnumerable<CategoriaResponseDTO>>(categorias);
            return Ok(categoriasDTO);
        }

        /// <summary>
        /// Retorna uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria (10 dígitos, mínimo 1000000001)</param>
        /// <response code="200">Categoria encontrada</response>
        /// <response code="404">Categoria não encontrada</response>
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(typeof(CategoriaResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaResponseDTO>> GetCategoria(long id)
        {
            var categoria = await _uof.CategoriaRepository.GetCategoriaComTransacoesAsync(id);

            if (categoria == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Categoria não encontrada.",
                    Detail = $"Nenhuma categoria encontrada com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            var categoriaDTO = _mapper.Map<CategoriaResponseDTO>(categoria);
            return Ok(categoriaDTO);
        }

        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria a ser atualizada</param>
        /// <param name="categoriaDTO">Dados atualizados da categoria</param>
        /// <response code="204">Categoria atualizada com sucesso</response>
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCategoria(long id, CategoriaRequestDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            categoria.CategoriaId = id;

            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();

            return NoContent();
        }

        /// <summary>
        /// Cria uma nova categoria
        /// </summary>
        /// <param name="categoriaDTO">Dados da nova categoria</param>
        /// <response code="201">Categoria criada com sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaResponseDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<CategoriaResponseDTO>> PostCategoria(CategoriaRequestDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);
            await _uof.Commit();

            var categoriaResponse = _mapper.Map<CategoriaResponseDTO>(categoriaCriada);
            return CreatedAtAction("GetCategoria", new { id = categoriaCriada.CategoriaId }, categoriaResponse);
        }

        /// <summary>
        /// Remove uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria a ser removida</param>
        /// <response code="204">Categoria removida com sucesso</response>
        /// <response code="404">Categoria não encontrada</response>
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategoria(long id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return NotFound(new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Categoria não encontrada.",
                    Detail = $"Nenhuma categoria encontrada com o id {id}.",
                    Instance = HttpContext.Request.Path
                });

            _uof.CategoriaRepository.Delete(categoria);
            await _uof.Commit();

            return NoContent();
        }
    }
}
