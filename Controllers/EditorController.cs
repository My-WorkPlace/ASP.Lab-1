using System.Linq;
using System.Threading.Tasks;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using ASP.Lab_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.Lab_1.Controllers
{
    public class EditorController : Controller
    {
        private readonly ISitesCategory _sitesCategory;
        private readonly IAllSites _allSites;
        private readonly AppDBContent _content;
        private CategoryListViewModel obj = new CategoryListViewModel();

        public EditorController(ISitesCategory sitesRepository, IAllSites allSites, AppDBContent content)
        {
            _sitesCategory = sitesRepository;
            _allSites = allSites;
            _content = content;
            obj.AllCategory = _sitesCategory.AllCategories;
        }
        public IActionResult AddSite()
        {
            ViewBag.Categories = new SelectList(_sitesCategory.AllCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveSite(Site site)
        {
            var category = _sitesCategory.AllCategories.FirstOrDefault(c => c.Id == site.CategoryId);
            var path = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            _content.Sites.Add(site);
            await _content.SaveChangesAsync();

            //return Redirect($"{path}/Home/Index");
            //return RedirectToAction("Index", "Home");
            //return View("~/Views/Home/Index.cshtml");
             return View("../Home/Index", obj);



        }

        public IActionResult AddCategory()
        {
            ViewBag.Categories = new SelectList(_sitesCategory.AllCategories, "Id", "Name");
            return View();
        }
    }
}