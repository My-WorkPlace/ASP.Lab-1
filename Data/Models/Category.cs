using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Lab_1.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]
        public string Image { get; set; }   
        public IEnumerable<Site> Sites { get; set; }
    }
}
