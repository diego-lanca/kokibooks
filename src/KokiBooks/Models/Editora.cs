using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KokiBooks.Models
{
    public class Editora
    { 
        [Key]
        public int id { get; set; }

        public string nome { get; set; } = "";
        public string site { get; set; } = "";
        public string endereco { get ; set;} = "";
        public string telefone { get; set; } = "";
    }
}