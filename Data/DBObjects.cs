using System.Collections.Generic;
using System.Linq;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.Sites.Any())
            {
                context.AddRange
                    (
                    new Site
                    {
                        Name = "Youtube",
                        UrlMainPage = "https://www.youtube.com/",
                        Category = Categories["Other"]
                    },
                    new Site
                    {
                        Name = "Google",
                        UrlMainPage = "https://www.google.com/",
                        Category = Categories["Other"]
                    },
                    new Site
                    {
                        Name = "Unian",
                        UrlMainPage = "https://www.unian.ua/",
                        Category = Categories["News"]
                    },
                    new Site
                    {
                        Name = "Правда",
                        UrlMainPage = "https://www.pravda.com.ua/news/",
                        Category = Categories["News"]
                    },
                    new Site
                    {
                        Name = "спорт",
                        UrlMainPage = "https://sport.ua/uk",
                        Category = Categories["Sport"]
                    },
                    new Site
                    {
                        Name = "УкрНет",
                        UrlMainPage = "https://www.ukr.net/news/sport.html",
                        Category = Categories["Sport"]
                    }
                    );
            }

            context.SaveChanges();

        }

        private static Dictionary<string, Category> _category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "News", Description = "Description news", Image = "/images/news.jpg"},
                        new Category {Name = "Sport", Description = "Description sport",Image = "/images/sport.jpg"},
                        new Category {Name = "Other", Description = "Description other",Image = "/images/Other.jpg"}
                    };
                    _category = new Dictionary<string, Category>();
                    foreach (var element in list)
                    {
                        _category.Add(element.Name, element);
                    }
                }

                return _category;
            }
        }
    }
}
