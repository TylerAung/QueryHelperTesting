using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QueryHelperTutorial.Models
{
    public class LibraryCollection
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public List<Book> books { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
