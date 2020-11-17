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
    public class CalculationController : ControllerBase
    {
        private libraryDbContext _dbContext;

        public CalculationController(libraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult> Calculate(int firsNumber, int secondNumber, string operation)
        {
        var result = 0;
        switch (operation)
        {
                case "+":
                    result = firsNumber+secondNumber;
                    break;
                case "-":
                    result = firsNumber-secondNumber;
                    break;
                case "*":
                    result = firsNumber*secondNumber;
                    break;
        }
        return StatusCode(200, result);
        }
    }
}
