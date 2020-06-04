using System.Collections.Generic;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Repository
{
    public class CategoryRepository:ISitesCategory
    {
        private AppDBContent _appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => _appDbContent.Categories;

    }
}
