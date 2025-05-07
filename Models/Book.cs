using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
