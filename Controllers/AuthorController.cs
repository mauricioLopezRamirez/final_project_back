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
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(
            [FromBody] Author author
        )
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return StatusCode(201, author);
        }
    }
}
