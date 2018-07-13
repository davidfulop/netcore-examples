using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {
        private static readonly Random _random = new Random();
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var time = _random.Next(20, 1500);
            await Task.Delay(time);
            return time.ToString();
        }
    }
}
