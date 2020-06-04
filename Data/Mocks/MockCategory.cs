using System.Collections.Generic;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Data.Mocks
{
    public class MockCategory:ISitesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {Name = "News", Description = "Description news", Image = "/images/news.jpg"},
                    new Category {Name = "Sport", Description = "Description sport",Image = "/images/sport.jpg"},
                    new Category {Name = "Other", Description = "Description other",Image = "/images/Other.jpg"}
                };
            }
        }
    }
}
