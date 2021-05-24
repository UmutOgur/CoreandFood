using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter the category name field")]
        [StringLength(20,ErrorMessage = "Please do not enter names under the 4 characters or  more than 20 characters.",MinimumLength = 4)]

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
