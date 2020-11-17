using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_api_swagger.Domain;
using net_api_swagger.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private libraryDbContext _dbContext;

        public GenreController(libraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
            return await _dbContext.Genres.AsNoTracking().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetForId(Guid id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            return StatusCode(200, genre);
        }
        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre(
            [FromBody] Genre genre
        )
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            var todoItem = await _dbContext.Genres.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = genre.Name;
            todoItem.Description = genre.Description;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var todoItem = await _dbContext.Genres.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _dbContext.Genres.Remove(todoItem);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(Guid id) =>
        _dbContext.Genres.Any(g => g.Id == id);
    }
}
