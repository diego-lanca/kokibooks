using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KokiBooks.Models
{
    public class Cliente
    {
        [Key]
        public int id {get; set;}

        private string nome {get; set;} = "";
        private string endereco { get; set; } = "";
        private string telefone { get; set; } = "";
        private int idBook { get; set; }
        private string dataInicio { get; set; } = "";
        private string devolucao { get; set; } = "";

    }
}