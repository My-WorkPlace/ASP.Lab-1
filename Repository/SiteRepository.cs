using System.Collections.Generic;
using System.Linq;
using ASP.Lab_1.Data;
using ASP.Lab_1.Data.Interfaces;
using ASP.Lab_1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Lab_1.Repository
{
    public class SiteRepository:IAllSites
    {
        private AppDBContent _appDbContent;

        public SiteRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Site> Sites => _appDbContent.Sites.Include(c => c.Category);
        public Site GetSiteById(int id) => _appDbContent.Sites.FirstOrDefault(p => p.Id == id);
    }
}
