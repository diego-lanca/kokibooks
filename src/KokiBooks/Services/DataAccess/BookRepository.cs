using Microsoft.EntityFrameworkCore;
using Deedle;
using System.Data;
using Spectre.Console;
using Table = Spectre.Console.Table;

namespace KokiBooks.Services.DataAccess
{
    public class BookRepository
    {
        public void selectAllBooks()
        {
            using (var context = new DataService())
            {

                // Define a variável livro e inclui as outras tabelas
                var livros = context.book.Include(b => b.autor).Include(b => b.editora);

                // Realiza a query, selecionando tudo de livros já com as outras tabelas
                var query = livros.Select(l => new
                {
                    Id = l.id,
                    Nome = l.nome,
                    Autor = l.autor != null ? l.autor.nome : null,
                    Editora = l.editora != null ? l.editora.nome : null,
                    Estado = l.emprestado == false ? "Disponível" : "Emprestado"
                });

                var table = new Table();
                var grid = new Grid();

                table.AddColumns("ID", "Nome", "Autor", "Editora", "Estado");

                foreach (var livro in query) {
                    table.AddRow(livro.Id.ToString(), livro.Nome, livro.Autor, livro.Editora, livro.Estado);
                    
                }

                table.Border(TableBorder.Rounded);
                table.Centered();
                AnsiConsole.Write(table);

            }
        }

        public void lendBook()
        {
            using (var context = new DataService())
            {

                int idLivro = chooseBook();

                var livroToUpdate = context.book.FirstOrDefault(b => b.id == idLivro);

                Console.WriteLine($"\n--- Livro Encontrado ---\nId: {livroToUpdate?.id} | Nome: {livroToUpdate?.nome}");

                Console.WriteLine("\nTem certeza que deseja emprestar este livro?\nDigite (S) ou (N): ");

                string confirmacao;
                bool continuar = false;

                do
                {
                    confirmacao = Console.ReadLine();

                    switch (confirmacao)
                    {
                        case "s" or "S":
                            continuar = true;
                            break;
                        case "n" or "N":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Comando não reconhecido, digite novamente: ");
                            break;
                    }
                } while (!(confirmacao.ToLower() == "s" || confirmacao.ToLower() == "n"));

                if (livroToUpdate != null)
                {
                    if (continuar == true) {

                        livroToUpdate.emprestado = true;

                        context.SaveChanges();
                    }
                }
            }
        }

        public void borrowBook()
        {
            using (var context = new DataService())
            {

                int idLivro = chooseBook();

                var livroToUpdate = context.book.FirstOrDefault(b => b.id == idLivro);

                Console.WriteLine($"\n--- Livro Encontrado ---\nId: {livroToUpdate?.id} | Nome: {livroToUpdate?.nome}");

                Console.WriteLine("\nTem certeza que esse livro foi devolvido?\nDigite (S) ou (N): ");

                string confirmacao;
                bool continuar = false;

                do
                {
                    confirmacao = Console.ReadLine();

                    switch (confirmacao)
                    {
                        case "s" or "S":
                            continuar = true;
                            break;
                        case "n" or "N":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Comando não reconhecido, digite novamente: ");
                            break;
                    }
                } while (!(confirmacao.ToLower() == "s" || confirmacao.ToLower() == "n"));

                if (livroToUpdate != null)
                {
                    if (continuar == true) {

                        livroToUpdate.emprestado = false;

                        context.SaveChanges();
                    }
                }
            }
        }

        private int chooseBook()
        {
            Console.WriteLine("Digite o ID do Livro que deseja selecionar: ");
            return Int32.Parse(Console.ReadLine());
        }
    }
}