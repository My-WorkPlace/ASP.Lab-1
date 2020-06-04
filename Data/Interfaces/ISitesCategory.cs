using System.Collections.Generic;
using ASP.Lab_1.Data.Models;

namespace ASP.Lab_1.Data.Interfaces
{
    public interface ISitesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
