// See https://aka.ms/new-console-template for more information

var manager = new LibraryManager.API.Models.LibraryManager();

while (true)
{
    Console.WriteLine("1. Add a new book");
    Console.WriteLine("2. List all books");
    Console.WriteLine("3. Find a book by ID");
    Console.WriteLine("4. Delete a book by ID");
    Console.WriteLine("5. Add a new User");
    Console.WriteLine("6. Register a Loan");
    Console.WriteLine("7. Return a book");
    Console.WriteLine("8. Exit");
    
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": 
            
            manager.AddBook();
            break;
        case "2":
            Console.WriteLine("Book List: ");
            Console.WriteLine("===================================");
            foreach (var book in manager.GetBooks())
            {
                Console.WriteLine(book.ToString());
            }
            break;
        case "3": Console.WriteLine("Enter book ID: ");
            var searchedBookId = Convert.ToInt32(Console.ReadLine());
            var searchedBook = manager.GetBookById(searchedBookId);
            if (searchedBook != null)
            {
                Console.WriteLine(searchedBook.ToString());
                break;
            }
            Console.WriteLine("Book not found.");
            break;
        case "4": Console.WriteLine("Enter book ID: ");
            var deletedBookId = Convert.ToInt32(Console.ReadLine());
            manager.DeleteBook(deletedBookId);
            break;
        case "5": manager.AddUser();
            break;
        case "6":
            manager.AddLending();
            break;
        case "7": manager.ReturnBook();
            break;
        case "8": Console.WriteLine("Exiting...");
            return;
    }
    
}