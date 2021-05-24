using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreandFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreandFood.Data;
using X.PagedList;
using System.IO;

namespace CoreandFood.Controllers
{
    public class FoodController : Controller
    {
        Context db = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page = 1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page, 5));//ToPagedList(page,5)) bu kısımda listelemede her sayfada 5 tane satır çıksın ya da 5 değer çıksın anlamına gelmektedir.
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Urunekle p)
        {
            Food food = new Food();
            if (p.ImageUrl != null)
            {
                var uzantı = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + uzantı;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resimler/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                food.ImageUrl = newimagename;

            }
            food.FoodName = p.FoodName;
            food.Price = p.Price;
            food.stock = p.stock;
            food.CategoryId = p.CategoryId;
            food.Description = p.Description;

            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            //var delete = db.Foods.Find(id);
            foodRepository.TDelete(new Food
            {
                FoodID = id
            });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);

            List<SelectListItem> values = (from y in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodID = x.FoodID,
                CategoryId = x.CategoryId,
                FoodName = x.FoodName,
                Price = x.Price,
                stock = x.stock,
                Description = x.Description,
                ImageUrl = x.ImageUrl

            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.FoodName = p.FoodName;
            x.stock = p.stock;
            x.Price = p.Price;
            x.ImageUrl = p.ImageUrl;
            x.Description = p.Description;
            x.CategoryId = p.CategoryId;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
