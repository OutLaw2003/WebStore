using WebStore.Models;

namespace WebStore.ViewModels
{
    public class BlogViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Blog> Blogs { get; set; }

        public String UserName { get; set; }
    }
}
