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
        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre(
            [FromBody] Genre genre
        )
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, genre);
        }
    }
}
