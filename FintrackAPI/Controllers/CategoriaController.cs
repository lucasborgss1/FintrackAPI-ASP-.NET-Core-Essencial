using Microsoft.AspNetCore.Mvc;
using FintrackAPI.Models;
using FintrackAPI.Repositories.Interfaces;

namespace FintrackAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        // GET: v1/api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _repository.GetCategoriasComTransacoesAsync();
            return Ok(categorias);
        }

        // GET: v1/api/Categoria/{id}
        [HttpGet("{id:long:min(1000000001):length(10)}")]
        public async Task<ActionResult<Categoria>> GetCategoria(long id)
        {
            var categoria = await _repository.GetCategoriaComTransacoesAsync(id);

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

            _repository.Update(categoria);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // POST: v1/api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _repository.Create(categoria);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        // DELETE: v1/api/Categoria/{id}
        [HttpDelete("{id:long:min(1000000001):length(10)}")]
        public async Task<IActionResult> DeleteCategoria(long id)
        {
            var categoria = await _repository.GetAsync(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _repository.Delete(categoria);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
