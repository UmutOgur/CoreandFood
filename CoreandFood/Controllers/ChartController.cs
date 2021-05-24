using CoreandFood.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.Controllers
{
    public class ChartController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisiualizeProductResult()
        {
            return Json(Prolist());
        }
        public List<Class1> Prolist()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "LCd",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisiualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.FoodName,
                    stock = x.stock
                }).ToList();
                return cs2;
            }
        }
        public IActionResult statistics()
        {
            var deger1 = db.Foods.Count();
            ViewBag.d1 = deger1;
            var deger2 = db.Categories.Count();
            ViewBag.d2 = deger2;
            var foid = db.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.d = foid;
            var deger3 = db.Foods.Where(x => x.CategoryId == foid).Count();
            ViewBag.d3 = deger3;
            var deger4 = db.Foods.Where(x => x.CategoryId == db.Categories.Where(z => z.CategoryName == "Vegatables").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;
            var deger5 = db.Foods.Sum(x => x.stock);
            ViewBag.d5 = deger5;
            var deger6 = db.Foods.Where(x => x.CategoryId == db.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryId).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;
            var deger7 = db.Foods.OrderByDescending(x => x.stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;
            var deger8 = db.Foods.OrderBy(x => x.stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = db.Foods.Average(x => x.Price);
            ViewBag.d9 = deger9;
            var deger10 = db.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            var deger10p = db.Foods.Where(y => y.CategoryId == deger10).Sum(x => x.stock);
            ViewBag.d10 = deger10p;
            var deger11 = db.Categories.Where(x => x.CategoryName == "Vegatables").Select(y => y.CategoryId).FirstOrDefault();
            var deger11p = db.Foods.Where(y => y.CategoryId == deger11).Sum(x => x.stock);
            ViewBag.d11 = deger11p;
            var deger12 = db.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d12 = deger12;
            return View();
        }
    }
}
