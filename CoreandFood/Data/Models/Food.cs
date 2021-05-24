using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }

        [Required(ErrorMessage = "Please enter the Food name field")]
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int stock { get; set; }

        [Required(ErrorMessage = "Please enter the Food name field")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
