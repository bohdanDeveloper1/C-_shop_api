using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using System.Collections.Generic;
using Shop.Api.Interfaces;
using Shop.Api.Data;
using Shop.Api.DataDB;
using System.Data.SqlClient;

namespace Shop.Api.Controllers 
{
    //починаємо звідси

    // це взяли з базового класу
    [ApiController]
    [Route("[controller]")]
    // буде повертати значення користувачу 
    public class ProductController : ControllerBase
    {

        private readonly IproductService _productService;
        public ProductController(IproductService productService)
        {
            this._productService = productService;
        }



        // щоб отримати інформацію 
        [HttpGet] // [HttpGet] перед функцією, яка буде виконувати  щоб працював json файл
        public IEnumerable<Product> Get() // IEnumerable<Product> пишемо замість типу данних
        {
            return _productService.GetALLProducts(); // отримуємо все з бази данних
        }

        // щоб додати новий екземпляр класу
        [HttpPost]
        public IActionResult Post(Product product)
        {
            _productService.AddNewProduct(product);
            return Created("", product);
        }
       


        [HttpPut]
        public IActionResult Put([FromBody] Product product) // з payload 
        {
            _productService.UpdateProduct(product);
            return Ok();
        }


        [HttpDelete]   // https://localhost:5001/Product&id =3              вписуємо в хром щоб видалити елемент
        // доробити видаляє продукт по ід
        public IActionResult Delete([FromQuery] int id)
        {
            _productService.GetProductById(id);
            return Ok();
            // якщо такий є   return Ok();

            // якщо немає   return NotFounf();

        }


        // дописати метод має виводити продукт ід якого ми вказали
        /*[HttpGet("GetByIdd")]
        public IActionResult GetById(Product product)
        {
            var product = _productService.GetproductById();
            if (product == null)
                return NotFound();
            else
                return Ok();
        }*/

    }
}
