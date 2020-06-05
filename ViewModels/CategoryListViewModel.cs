using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP.Lab_1.Data.Models;
using Microsoft.AspNetCore.Http;

namespace ASP.Lab_1.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> AllCategory { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        public IFormFile Image { get; set; }
    }
}
