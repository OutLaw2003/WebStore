using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly CarStoreContext _context;
        public BlogController(CarStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var prods = await _context.Products.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var viewModel = new ProductViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Prods = prods,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> BlogDetail(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var prods = await _context.Products.Where(m => m.Link == slug && m.IdPro ==
            id).ToListAsync();
            if (prods == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error",
                };
                return View("Error", errorViewModel);
            }
            var viewModel = new ProductViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Prods = prods,
            };
            return View(viewModel);
        }
    }
}

        
    

