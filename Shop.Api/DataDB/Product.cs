using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

#nullable disable

namespace Shop.Api.DataDB
{
    public partial class Product
    {
        [FromQuery]
        public int? Id { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quntity { get; set; }
        public string Category { get; set; }
    }
}

//кожен метод має бути доданий до інтерфейса
//алгоритм
// 1 додаємо до ProductControler      можна взагалі писати все тільки в цьому класі
// 2 додаємо метод в IProductServise            інтерфейси викликають методи
// 3 додаємо новий метод в клас ProductServise      перехідний клвс між ProductControler і ProductRepo
// 4 додаємо метод в IProductRepo
// 5 додаємо метод в ProductRepo                    основа, де пишемо методи з тілом
