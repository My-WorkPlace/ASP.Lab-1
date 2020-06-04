using System.Collections.Generic;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.ViewModels
{
    public class SiteListViewModel
    {
        public string CurrCategory { get; set; }    
        public IEnumerable<Site> AllSites { get; set; }
    }
}
