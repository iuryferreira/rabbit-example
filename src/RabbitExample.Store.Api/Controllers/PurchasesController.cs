using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RabbitExample.Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PurchasesController> _logger;

        public PurchasesController(ILogger<PurchasesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Store()
        {
            return Ok();
        }
    }
}