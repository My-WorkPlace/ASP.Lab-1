namespace ASP.Lab_1.Data.Models
{
    public class Site
    {
        public int Id { get; set; }
        public string UrlMainPage { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }
        //контакний e-mail,
        //орієнтовна кількість проіндексованих сторінок,
        //середня кількість відвідувачів за добу, індекс Google PR,
        //URL карти сайту, список ключових слів та словосполучень,
        //нікнейм користувача, що додав опис.
        // Piece of shit idk if need
    }
}
