using System.Collections.Generic;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Data.Interfaces
{
    public interface IAllSites
    {
        IEnumerable<Site> Sites { get;}
        Site GetSiteById(int id);
    }
}
