using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ContactController : Controller
    {
        private readonly CarStoreContext _context;
        public ContactController(CarStoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var viewModel = new ContactViewModel
            {
                Menus = menus,
                Blogs = blogs,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
    }
}

