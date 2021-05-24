using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Data.Models
{
    public class Urunekle
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int stock { get; set; }
        public int CategoryId { get; set; }
    }
}
