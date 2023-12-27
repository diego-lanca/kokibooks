using Microsoft.EntityFrameworkCore;
using Deedle;
using System.Data;

namespace KokiBooks.Services.DataAccess
{
    public class BookRepository
    {
        public void selectAllBooks() {
            using (var context = new DataService()) {
                
                // Define a variável livro e inclui as outras tabelas
                var livros = context.book.Include(b => b.autor).Include(b => b.editora);

                // Realiza a query, selecionando tudo de livros já com as outras tabelas
                var query = livros.Select(l => new 
                { Id = l.id, 
                Nome = l.nome, 
                Autor = l.autor != null ? l.autor.nome : null, 
                Editora = l.editora != null ? l.editora.nome : null,
                Estado = l.emprestado == false ? "Disponível" : "Emprestado" });

                // Transforma os resultados em um Frame do Deedle
                var frame = Frame.FromRecords(query);

                // Imprime todos os resultados encontrados
                frame.Print();

            }
        }

        public void lendBook() {
            using (var context = new DataService()) {

                int idLivro = chooseBook();

                var livroToUpdate = context.book.FirstOrDefault(b => b.id == idLivro);

                Console.WriteLine($"--- Livro Encontrado ---\nId: {livroToUpdate?.id} | Nome: {livroToUpdate?.nome}");

                if (livroToUpdate != null) {

                    bool confirmacao;
                    
                    livroToUpdate.emprestado = true;

                    context.SaveChanges();
                }
            }
        }

        private int chooseBook() {
            Console.WriteLine("Digite o ID do Livro que deseja selecionar: ");
            return Int32.Parse(Console.ReadLine());
        }
    }
}