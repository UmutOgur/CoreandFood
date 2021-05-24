using CoreandFood.Data;
using CoreandFood.Data.Models;
using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke(int id)
        {
           

            FoodRepository repository = new FoodRepository();
            var FoodList = repository.List(y => y.CategoryId == id);
            return View(FoodList);
        }
    }
}
