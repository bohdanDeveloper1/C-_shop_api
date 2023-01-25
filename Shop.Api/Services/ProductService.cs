using Microsoft.AspNetCore.Mvc;
using Shop.Api.Data;
using Shop.Api.DataDB;
using Shop.Api.Interfaces;
using Shop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Services
{
    // щоб вивести екземпляри класу Product
    // тут мають бути всі методи 
    // посередник 
    public class ProductService : IproductService
    {
        private readonly IProductRepo productRepo;

        public ProductService(IProductRepo productRepo) // конструктор, який отримує інтерфейс
        {
            this.productRepo = productRepo; // передає інтерфейс
        }

        // TODO:
        public void AddNewProduct(Product product)
        {
            // перевіряємо чи всі поля заповнені
            // перевіряємо чи немає такого продукту в базі, якщо є, збільшуємо кількість

            productRepo.Add(product);
        }

        public void Delete(Product id)
        {
            // перевіряємо чи всі поля заповнені
            // перевіряємо чи немає такого продукту в базі, якщо є, збільшуємо кількість

            productRepo.Remove(id);
        }

        public IEnumerable<Product> GetALLProducts() //повертає екземпляри класу Product
        {
            return productRepo.GetAllProducts(); //має ссилки на оба інтерфейси
        }

        //public bool GetProductById([FromQuery] Product id)
        //{
        //    return productRepo.Contains(id);
        //}

        public bool GetProductById([FromQuery] int id)
        {
            throw new NotImplementedException();
        }


        public void UpdateProduct(Product product)
        {

            // перевірка чи існує елемент в базі данних
            /* var r = productRepo.GetAllProducts().FirstOrDefault(p => p.Id == product.Id);
              if (r is null)
              {
                  productRepo.Add(product);
                  return;
              }

              productRepo.UpdateProduct(product);*/
        }
    }
}
