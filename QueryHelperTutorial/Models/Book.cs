using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHelperTutorial.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public virtual Author author { get; set; }

        public string BookTitle { get; set; }

        public string BookDescription { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
