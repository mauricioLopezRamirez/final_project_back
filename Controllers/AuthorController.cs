using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_api_swagger.Domain;
using net_api_swagger.Infrastructure;

namespace net_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private libraryDbContext _dbContext;

        public AuthorController(libraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return await _dbContext.Authors.AsNoTracking().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetForId(Guid id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            return StatusCode(200, author);
        }
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(
            [FromBody] Author author
        )
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            var todoItem = await _dbContext.Authors.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = author.Name;
            todoItem.Email = author.Email;

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
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var todoItem = await _dbContext.Authors.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _dbContext.Authors.Remove(todoItem);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(Guid id) =>
        _dbContext.Authors.Any(a => a.Id == id);
    }
}
