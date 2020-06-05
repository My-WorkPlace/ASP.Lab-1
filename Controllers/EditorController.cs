using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using ASP.Lab_1.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
        //private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditorController(ISitesCategory sitesRepository, IAllSites allSites, AppDBContent content,IHostingEnvironment hostingEnvironment)
        {
            _sitesCategory = sitesRepository;
            _allSites = allSites;
            _content = content;
            obj.AllCategory = _sitesCategory.AllCategories;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult AddSite()
        {
            ViewBag.Categories = new SelectList(_sitesCategory.AllCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveSite(Site site)
        {
            //TODO if site is null return or validation
            var category = _sitesCategory.AllCategories.FirstOrDefault(c => c.Id == site.CategoryId);
            var path = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            _content.Sites.Add(site);
            await _content.SaveChangesAsync();

            //return Redirect($"{path}/Home/Index");
            //return RedirectToAction("Index", "Home");
            //return View("~/Views/Home/Index.cshtml");
             return View("../Home/Index", obj);
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveCategory(Category category)
        //{
        //    _content.Categories.Add(category);
        //    await _content.SaveChangesAsync();
        //    return View("../Home/Index", obj);
        //}

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryListViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Image != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Category newEmployee = new Category
                {
                    Name = model.Name,
                    Description = model.Description,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Image = uniqueFileName
                };

                _content.Categories.Add(newEmployee);
                await _content.SaveChangesAsync();
                //return RedirectToAction("details", new { id = newEmployee.Id });
                //return View();
                return View("../Home/Index", obj);
            }

            //return View();
            return View("../Home/Index", obj);
        }

    }
}