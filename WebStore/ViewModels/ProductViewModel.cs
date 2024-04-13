﻿using WebStore.Models;

namespace WebStore.ViewModels
{
    public class ProductViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Product> Prods { get; set; }
        public String cateName { get; set; }
    }
}
