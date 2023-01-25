using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Shop.Api.DataDB;

namespace Shop.Api.Models
{
    public class Database
    {

        Product newUser = new Product();
            private string _connectionstring = "Server=.;Database=C#_Api;Integrated Security=True;TrustServerCertificate=True";

        public void AddNewUser(Product newproduct)
        {
            var query = $"insert into [Products](id,  _description, price, quntity, category) values ({newproduct.Id},'{newproduct.Description}'," +
              $"'{newproduct.Price}', {newproduct.Quntity}, '{newproduct.Category}')";

            ExecuteCommand(query);

        }

        private void ExecuteCommand(string query)  // стандарт для всіх виконує підключення
        {
            var sqlConnection = new SqlConnection(_connectionstring);
            sqlConnection.Open();
            var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            sqlConnection.Dispose();


            sqlConnection.Close();
        }



        /* public void Delete() // public void  (User newUser)
         {
             var query = $"delete from [User] where Id = 1";

             ExecuteCommand(query);
         }

         public void Update(Product newUser) // передаємо екземпляр класу
         {

             var query = $"update [User] set LastName = '{newUser.LastName}' where id = {newUser.Id}";

             ExecuteCommand(query);
         }

         public IEnumerable<Product> GetAll() // виводить всіх користувачів
         {
             var result = new List<User>();
             var query0 = "select * from [User]";
             var sqlConnection = new SqlConnection(_connectionstring);
             sqlConnection.Open();
             var sqlCommand = new SqlCommand(query0, sqlConnection);

             var reader = sqlCommand.ExecuteReader();

             reader.Read(); //повертає тру фолс,   use for while

             while (reader.Read())
             {
                 var id = int.Parse(reader["Id"].ToString());
                 var first = reader["FirstName"].ToString();
                 var last = reader["LastName"].ToString();
                 var age = byte.Parse(reader["age"].ToString());
                 var mail = reader["Email"].ToString();

                 *//* foreach (var item in result)
                  {
                      Console.WriteLine($"id: {newUser.Id}, UserLastName: {newUser.LastName}"); //замінити, не правильно працює               
                  }*//*

                 var user = new Product { Id = id, FirstName = first, LastName = last, age = age, Email = mail };
                 result.Add(user);

             }

             sqlCommand.Dispose();
             sqlConnection.Dispose();


             return result;
         }*/


        /*  public IEnumerable<Product> FilterByFirstName(string syntex) // фільтр на ввод користувача
          {
              var query0 = $"select * from [User] where FirtsName like @Value "; // фільтр на ввод користувача '@Value'
              var result = new List<Product>();
              var sqlConnection = new SqlConnection(_connectionstring);
              sqlConnection.Open();
              var sqlCommand = new SqlCommand(query0, sqlConnection);

              sqlCommand.Parameters.AddWithValue("@Value", syntex + "%"); // фільтр на ввод користувача

              var reader = sqlCommand.ExecuteReader();

              reader.Read();//повертає тру фолс,   use for while

              while (reader.Read())
              {
                  var id = int.Parse(reader["Id"].ToString());
                  var first = reader["FirstName"].ToString();
                  var last = reader["LastName"].ToString();
                  var age = byte.Parse(reader["age"].ToString());
                  var mail = reader["Email"].ToString();



                  var user = new Product { Id = id, FirstName = first, LastName = last, age = age, Email = mail };
                  result.Add(user);

              }
              sqlCommand.Dispose();
              sqlConnection.Dispose();

              return result;
          }*/


        /* private void ExecuteCommand(string query)  // стандарт для всіх виконує підключення
         {
             var sqlConnection = new SqlConnection(_connectionstring);
             sqlConnection.Open();
             var sqlCommand = new SqlCommand(query, sqlConnection);

             sqlCommand.ExecuteNonQuery();

             sqlCommand.Dispose();
             sqlConnection.Dispose();


             sqlConnection.Close();
         }*/
    }
}

