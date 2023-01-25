using Microsoft.AspNetCore.Mvc;
using Shop.Api.DataDB;
using Shop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Interfaces
{
    // тут валідація
    // це можна оминути
    public interface IproductService 
    {
        IEnumerable<Product> GetALLProducts(); // отримує екземпляри класу Product

       void AddNewProduct(Product product); // додає отримані екземпляри класу Product

        bool GetProductById([FromQuery] int id);

      //  bool GetproductById(Product id);
        void Delete(Product id);

        void UpdateProduct(Product product);

      
    }
}
