using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitExample.Shared.Requests;
using RabbitExample.Shared.Responses;

namespace RabbitExample.Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<PurchasesController> _logger;
        private IBus _bus;

        public PurchasesController(ILogger<PurchasesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> StoreAsync(int id)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");
            var obj = new GetProductRequest { Id = id };
            var result = await _bus.Rpc.RequestAsync<GetProductRequest, GetProductResponse>(obj);
            return Ok(result);
        }
    }
}