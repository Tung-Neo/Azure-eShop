using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.ViewModels;


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
            => View(new ProductListViewModel
            {
                Products = repositiry.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repositiry.Products.Count()
                }
            });
    }
}
