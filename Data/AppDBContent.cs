using ASP.Lab_1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.Lab_1.Data
{

    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
