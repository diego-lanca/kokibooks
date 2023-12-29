using KokiBooks.Services.DataAccess;

// // See https://aka.ms/new-console-template for more information
Console.Clear();
Console.WriteLine("Inicializando serviço...");
var books = new BookRepository();

// books.selectAllBooks();
// books.lendBook();
// books.selectAllBooks();

bool menu = true;

while (menu) {
    Console.WriteLine("Seja bem-vindo a KokiBooks!\nSelecione a opção que deseja: ");
    Console.WriteLine("(1) - Verificar livros\n(2) - Empréstimo de Livro\n(3) - Devolução de Livro\n(4) - Sair");
    var resposta = Console.ReadLine();

    Console.Clear();
    switch (resposta) {
        case "1":
            books.selectAllBooks();
            break;
        case "2":
            books.lendBook();
            break;
        case "3":
            books.borrowBook();
            break;
        case "4":
            menu = false;
            break;
        default:
            break;
    }

    Console.WriteLine("\nAperte qualquer botão para prosseguir...");
    Console.ReadLine();
    Console.Clear();

}

