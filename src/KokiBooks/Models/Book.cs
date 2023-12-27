using System.ComponentModel.DataAnnotations;

namespace KokiBooks.Models
{
    public class Book
    {
        [Key]
        public int id {get; set;}

        public string nome {get; set;} = "";
        public int qtdPaginas {get; set;}
        public int idAutor {get; set;}
        public Author ?autor;
        public int idEditora {get; set;}
        public Editora ?editora;
        public bool emprestado {get; set;}

    }
}