﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHelperTutorial.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }
    }
}
