using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarStoreContext _context;
        public HomeController(CarStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            var slides = await _context.Sliders.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var cat_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat ==
            1).OrderBy(m => m.Order).Take(3).ToListAsync();
			var dog_cate_prods = await _context.Catologies.Where(m => m.IdCat ==
            1).FirstOrDefaultAsync();
			var dog_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat ==
            2).OrderBy(m => m.Order).Take(3).ToListAsync();
			var cat_cate_prods = await _context.Catologies.Where(m => m.IdCat ==
            2).FirstOrDefaultAsync();
			var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new HomeViewModel
            {
                Blogs = blogs,
                Menus = menus,
                Sliders = slides,
                CatProds = cat_prods,
                DogProds = dog_prods,
				CatCateProds = cat_cate_prods,
				DogCateProds = dog_cate_prods,
			};

            return View(viewModel);
           
        }
        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _SlidePartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _ProductPartial()
        {
            return PartialView();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
