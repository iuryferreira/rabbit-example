using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.Extensions.Hosting;
using RabbitExample.Shared;
using RabbitExample.Shared.Requests;
using RabbitExample.Shared.Responses;

namespace RabbitExample.Product.Api
{
    public class ProductRabbitHandler : BackgroundService
    {
        private IBus _bus;

        public ProductRabbitHandler(IBus bus)
        {
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("localhost:5672");
            _bus.Rpc.RespondAsync<GetProductRequest, GetProductResponse>(GetProduct, stoppingToken);
            return Task.CompletedTask;
        }

        private static GetProductResponse GetProduct(GetProductRequest request)
        {
            var products = new Products();
            var product = products.Value.FirstOrDefault(x => x.Id == request.Id);
            if (product != null) return new() { Id = product.Id, Name = product.Name };
            return new();
        }
    }
}