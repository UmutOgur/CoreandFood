using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreandFood.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoriyRepository categoriyRepository = new CategoriyRepository();
            var categoryList = categoriyRepository.TList();
            return View(categoryList);
        }
    }
}
