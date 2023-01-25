using Microsoft.AspNetCore.Mvc;
using Shop.Api.DataDB;
using Shop.Api.Interfaces;
using Shop.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.Data
{
    //містить методи Add, Perewirka, GetproductById
    // містить базу данних і повертає всі її елементи

    // тут додаємо 
    public class ProductRepo : IProductRepo
    {
        // замість цього маэ бути база данних
        public static List<Product> _products = new List<Product> //лист з екземплярами класів
        {
         

    };

        public static bool GetproductById(Product product) //перевірка чи такий екземпляр класу існує
        {
            return _products.Contains(product); //повертаємо true or false
        }
        private void ExecuteCommand(string query)  // (стандарт для всіх) підключається до бд та передає туди query
        {
            var sqlConnection = new SqlConnection("Server=DESKTOP-03HVO1F;Database=C#_Api;Trusted_Connection=True;");
            sqlConnection.Open();
            var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            sqlConnection.Dispose();


            sqlConnection.Close();
        }

        public void Add(Product product) //реалізація інтерфейсу
        {
            _products.Add(product); //додаємо продукт в лист
          
            
                var query = $"insert into [Products](id,  _description, price, quntity, category) values ({product.Id},'{product.Description}'," +
                  $"'{product.Price}', {product.Quntity}, '{product.Category}')";

                ExecuteCommand(query);
                     
        }

        public void Remove(Product id) //передаємо id й видаляємо екземпляр класу з цим id
        {
            //зробити перевірку чи такий продукт є в листі
          bool validation =  ProductRepo.GetproductById(id);
         if(validation == true)
            {
                _products.Remove(id); // видаляємо продукт з листа

                var query = $"delete from [Products] where id = {id}";    //DELETE

                ExecuteCommand(query);
            }

        }

        public IEnumerable<Product> GetAllProducts() //мабуть не спрацює - треба робити через foreach
        {
            var query = $"select * from Products";

            ExecuteCommand(query);

            return _products; //взяти дані з бд замість цього
        }

        /*   public bool GetProductById([FromQuery] int id)
           {
               throw new NotImplementedException();
           }*/

        public bool GetProductById([FromQuery] Product id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product) // замінить існуючий елемент на новий
        {
            var query = $"update Products set {product} where id = {product.Id}";
            ExecuteCommand(query);
            // це як запит до дб
            // можна було просто написати запит
            var p = _products.First(p => p.Id == product.Id);
            var index = _products.IndexOf(p);
            _products[index] = product;
        }
    }
}
