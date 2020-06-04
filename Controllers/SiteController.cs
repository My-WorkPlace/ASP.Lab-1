using System.Linq;
using System.Threading.Tasks;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using ASP.Lab_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Lab_1.Controllers
{
    [Controller]
    public class SiteController:Controller
    {
        private readonly IAllSites _allSites;
        private readonly ISitesCategory _sitesCategory;

  
        

        public SiteController(IAllSites allSites,ISitesCategory sitesCategory)
        {
            _allSites = allSites;
            _sitesCategory = sitesCategory;

        }

        [Route("Site/List")]
        public ViewResult List()
        {
            ViewBag.Title = "Page with shit";
            var obj = new SiteListViewModel();
            obj.AllSites = _allSites.Sites;
            obj.CurrCategory = "Sites table";
            return View(obj);
        }

        public ViewResult AllSites()
        {
            var obj = new SiteListViewModel();
            obj.AllSites = _allSites.Sites;
            obj.CurrCategory = "Sites table";
            return View(obj);
        }

        [Route("Site/Category")]
        public ViewResult Category()
        {
            var obj = new CategoryListViewModel();
            obj.AllCategory = _sitesCategory.AllCategories;
            return View(obj);
        }

    }
}
