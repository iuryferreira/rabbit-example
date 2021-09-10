using System;
using System.Collections.Generic;

namespace RabbitExample.Shared
{
    public class Products
    {
        public IReadOnlyCollection<Product> Value { get; }

        public Products()
        {
            Value = new[] { new Product { Id = 1, Name = "Lápis" }, new Product { Id = 2, Name = "Caneta" } };
        }
    }
}