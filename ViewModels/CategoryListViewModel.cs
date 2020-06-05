using System.Collections.Generic;
using ASP.Lab_1.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ASP.Lab_1.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> AllCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
