using Microsoft.AspNetCore.Mvc;
using Shop.Api.DataDB;
using Shop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Interfaces
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts(); //отримує екземпляри класу Product

        void Add(Product product);
        void Remove(Product id);

        bool GetProductById([FromQuery] Product id);

        void UpdateProduct(Product product);
    }
}
