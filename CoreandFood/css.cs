using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood
{
    public class css : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
