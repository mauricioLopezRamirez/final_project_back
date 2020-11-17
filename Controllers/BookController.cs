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
    public class BookController : ControllerBase
    {
        private libraryDbContext _dbContext;

        public BookController(libraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetForId(Guid id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            return StatusCode(200, book);
        }
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(
            [FromBody] Book book
        )
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var todoItem = await _dbContext.Books.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = book.Name;
            todoItem.Year = book.Year;
            todoItem.AuthorId = book.AuthorId;
            todoItem.GenreId = book.GenreId;

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
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var todoItem = await _dbContext.Books.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(todoItem);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(Guid id) =>
        _dbContext.Books.Any(b => b.Id == id);
    }
}
