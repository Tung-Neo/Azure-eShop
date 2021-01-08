using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepositiry repositiry;
        public int PageSize = 4;

        public HomeController(IAppRepositiry repo)
        {
            repositiry = repo;
        }

        //public IActionResult Index() => View(repositiry.Products);

        public ViewResult Index(int productPage = 1)
            => View(repositiry.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                );
    }
}
