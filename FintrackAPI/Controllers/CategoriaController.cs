using Microsoft.AspNetCore.Mvc;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CategoriaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        // GET: v1/api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _uof.CategoriaRepository.GetCategoriasComTransacoesAsync();
            return Ok(categorias);
        }

        // GET: v1/api/Categoria/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<Categoria>> GetCategoria(long id)
        {
            var categoria = await _uof.CategoriaRepository.GetCategoriaComTransacoesAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: v1/api/Categoria/{id}
        [HttpPut("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> PutCategoria(long id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();

            return NoContent();
        }

        // POST: v1/api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            var categoriaCriada = _uof.CategoriaRepository.Create(categoria);
            await _uof.Commit();

            return CreatedAtAction("GetCategoria", new { id = categoriaCriada.CategoriaId }, categoriaCriada);
        }

        // DELETE: v1/api/Categoria/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteCategoria(long id)
        {
            var categoria = await _uof.CategoriaRepository.GetAsync(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _uof.CategoriaRepository.Delete(categoria);
            await _uof.Commit();

            return NoContent();
        }
    }
}
