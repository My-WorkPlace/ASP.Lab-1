using System.Collections.Generic;
using System.Linq;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Data.Mocks
{
    public class MockSite : IAllSites
    {
        private readonly ISitesCategory _categorySites = new MockCategory();

        public IEnumerable<Site> Sites
        {
            get
            {
                return new List<Site>
                {
                    new Site
                    {
                        Name = "Youtube",
                        UrlMainPage = "https://www.youtube.com/",
                        Category = _categorySites.AllCategories.First(c => c.Name=="Other")
                    },
                    new Site
                    {
                    Name = "Google",
                    UrlMainPage = "https://www.google.com/",
                    Category = _categorySites.AllCategories.First(c => c.Name=="Other")
                    },
                    new Site
                    {
                        Name = "Unian",
                        UrlMainPage = "https://www.unian.ua/",
                        Category = _categorySites.AllCategories.First(c => c.Name=="News")
                    },
                    new Site
                    {
                        Name = "Правда",
                        UrlMainPage = "https://www.pravda.com.ua/news/",
                        Category = _categorySites.AllCategories.First(c => c.Name=="News")
                    },
                    new Site
                    {
                        Name = "спорт",
                        UrlMainPage = "https://sport.ua/uk",
                        Category = _categorySites.AllCategories.First(c => c.Name=="Sport")
                    },
                    new Site
                    {
                        Name = "УкрНет",
                        UrlMainPage = "https://www.ukr.net/news/sport.html",
                        Category = _categorySites.AllCategories.First(c => c.Name=="Sport")
                    },
                };
            }
        }
        public Site GetSiteById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
