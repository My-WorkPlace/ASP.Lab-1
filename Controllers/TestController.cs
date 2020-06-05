using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using ASP.Lab_1.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Lab_1.Controllers
{
    public class TestController : Controller
    {
        private readonly AppDBContent dbContext;
        private readonly ISitesCategory _category;
        private readonly IWebHostEnvironment webHostEnvironment;
        public TestController(AppDBContent context, IWebHostEnvironment hostEnvironment, ISitesCategory category)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _category = category;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var category = await dbContext.Employees.ToListAsync();
        //    return View(employee);
        //}

        public IActionResult Index()
        {
            var category = _category.AllCategories.ToList();
            return View(category);
        }


        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(CategoryListViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                var employee = new Category
                {
                    Name = model.Name,
                    Description = model.Description,
                    Image = uniqueFileName,
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(CategoryListViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}