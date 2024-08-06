using bookDemo.Models;

namespace bookDemo.Data
{
    public static class AplicationContext
    {
        public static List<Book>Books { get; set; }
        static AplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1,Title="Şeker Portakalı",Price=100},
                new Book(){Id=2,Title="Güneşi Uyandıralım",Price=75},
                new Book(){Id=3,Title="Delifişek",Price=55}
            };
        }
    }
}
