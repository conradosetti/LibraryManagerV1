// See https://aka.ms/new-console-template for more information

var gerenciador = new LibraryManager.API.Models.LibraryManager();

while (true)
{
    Console.WriteLine("1. Add a new book");
    Console.WriteLine("2. List all books");
    Console.WriteLine("3. Find a book by ID");
    Console.WriteLine("4. Delete a book by ID");
    Console.WriteLine("5. Exit");
    
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": Console.WriteLine("Enter book ID: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Enter author: ");
            var author = Console.ReadLine();
            Console.WriteLine("Enter book ISBN: ");
            var isbn = Console.ReadLine();
            Console.WriteLine("Enter book publish date: ");
            var publishDate = Convert.ToInt32(Console.ReadLine());
            
            gerenciador.AddBook(id, title, author, isbn, publishDate);
            break;
        case "2":
            Console.WriteLine("Book List: ");
            Console.WriteLine("===================================");
            foreach (var book in gerenciador.GetBooks())
            {
                Console.WriteLine(book.ToString());
            }
            break;
        case "3": Console.WriteLine("Enter book ID: ");
            var searchedBookId = Convert.ToInt32(Console.ReadLine());
            var searchedBook = gerenciador.GetBookById(searchedBookId);
            if (searchedBook != null)
            {
                Console.WriteLine(searchedBook.ToString());
                break;
            }
            Console.WriteLine("Book not found.");
            break;
        case "4": Console.WriteLine("Enter book ID: ");
            var deletedBookId = Convert.ToInt32(Console.ReadLine());
            gerenciador.DeleteBook(deletedBookId);
            break;
        case "5": Console.WriteLine("Exiting...");
            return;
    }
    
}