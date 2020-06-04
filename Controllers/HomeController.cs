﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using ASP.Lab_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISitesCategory _sitesCategory;
        private readonly IAllSites _allSites;
        private readonly AppDBContent _content;

        public HomeController(ISitesCategory sitesRepository, IAllSites allSites, AppDBContent content)
        {
            _sitesCategory = sitesRepository;
            _allSites = allSites;
            _content = content;
        }

        public ViewResult Index()
        {
            var obj = new CategoryListViewModel();
            obj.AllCategory = _sitesCategory.AllCategories;
            return View(obj);
        }

        [Route("Home/List")]
        [Route("Home/List/{category}")]
        public IActionResult List(string category)
        {
            var _category = category;
            IEnumerable<Site> sites = null;
            var currCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                sites = _allSites.Sites.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("News", category, StringComparison.OrdinalIgnoreCase))
                {
                    sites = _allSites.Sites.Where(c => c.Category.Name.Equals("News")).OrderBy(i => i.Id);
                    currCategory = "News";
                }
                else if (string.Equals("Sport", category, StringComparison.OrdinalIgnoreCase))
                {
                    sites = _allSites.Sites.Where(c => c.Category.Name.Equals("Sport")).OrderBy(i => i.Id);
                    currCategory = "Sport";
                }
                else if (string.Equals("Other", category, StringComparison.OrdinalIgnoreCase))
                {
                    sites = _allSites.Sites.Where(c => c.Category.Name.Equals("Other")).OrderBy(i => i.Id);
                    currCategory = "Other";
                }
            }

            var obj = new SiteListViewModel();
            obj.AllSites = sites.ToList();
            obj.CurrCategory = "Sites table";

            ViewBag.Title = "Page with cars";
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Site site)
        {
            _content.Sites.Add(site);
            await _content.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}