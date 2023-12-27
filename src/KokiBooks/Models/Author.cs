using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KokiBooks.Models
{
    public class Author
    {
        [Key]
        public int id {get; set;}

        public string nome {get; set;} = "";
        public int idade {get; set;}

        // Relacionamento 1:N com Books
        public List<Book> ?book { get; set; }
    }
}