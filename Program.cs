using KokiBooks.Services.DataAccess;
using Spectre.Console;

// // See https://aka.ms/new-console-template for more information
Console.Clear();
var books = new BookRepository();

// books.selectAllBooks();
// books.lendBook();
// books.selectAllBooks();

bool menu = true;

while (menu) {
    AnsiConsole.MarkupLine("[underline red]Seja bem-vindo a KokiBooks![/]");

    var resposta = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Selecione a opção desejada")
        .PageSize(4)
        .AddChoices(new [] {
            "Verificar livros", "Empréstimo de Livro", "Devolução de Livro", "Sair"
        }));

    switch (resposta) {
        case "Verificar livros":
            books.selectAllBooks();
            break;
        case "Empréstimo de Livro":
            books.lendBook();
            break;
        case "Devolução de Livro":
            books.borrowBook();
            break;
        case "Sair":
            menu = false;
            break;
        default:
            break;
    }

    Console.WriteLine("\nAperte qualquer botão para prosseguir...");
    Console.ReadLine();
    Console.Clear();

}

