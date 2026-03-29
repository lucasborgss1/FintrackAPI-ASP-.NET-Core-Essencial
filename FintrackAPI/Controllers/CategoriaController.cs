using AutoMapper;
using FintrackAPI.DTOs.Categoria;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CategoriaController(IUnitOfWork uof, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _uof = uof;
        private readonly IMapper _mapper = mapper;

        // GET: v1/api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDTO>>> GetCategorias()
        {
            var categorias = await _uof.CategoriaRepository.GetCategoriasComTransacoesAsync();
            var categoriasDTO = _mapper.Map<IEnumerable<CategoriaResponseDTO>>(categorias);
            return Ok(categoriasDTO);
        }

        // GET: v1/api/Categoria/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
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

        // PUT: v1/api/Categoria/{id}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutCategoria(long id, CategoriaRequestDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            categoria.CategoriaId = id;

            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();

            return NoContent();
        }

        // POST: v1/api/Categoria
        [HttpPost]
        public async Task<ActionResult<CategoriaResponseDTO>> PostCategoria(CategoriaRequestDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);
            await _uof.Commit();

            var categoriaResponse = _mapper.Map<CategoriaResponseDTO>(categoriaCriada);
            return CreatedAtAction("GetCategoria", new { id = categoriaCriada.CategoriaId }, categoriaResponse);
        }

        // DELETE: v1/api/Categoria/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
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
