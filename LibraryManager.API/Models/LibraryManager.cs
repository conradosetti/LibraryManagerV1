namespace LibraryManager.API.Models;

public class LibraryManager
{
    private List<BookModel?> books = new ();

    public void AddBook()
    {
        string title, author, isbn;
        int id, year;
        do
        {
            Console.WriteLine("Enter book ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
                Console.WriteLine("Id must be greater than zero");
            if (books.Any(book => book.Id == id))
            {
                Console.WriteLine("Id must be unique.");
            }
        } while (id <= 0 || books.Any(book => book.Id == book.Id));
        do
        {
            Console.WriteLine("Enter book title: ");
            title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
                Console.WriteLine("Title must not be empty.");
        } while (string.IsNullOrWhiteSpace(title));
        
        
        do
        {
            Console.WriteLine("Enter author: ");
            author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
                Console.WriteLine("Author must not be empty.");
        } while (string.IsNullOrWhiteSpace(author));
        
        do
        {
            Console.WriteLine("Enter book ISBN: ");
            isbn = Console.ReadLine();
            if (!(!string.IsNullOrWhiteSpace(isbn) && isbn.Length == 13 && long.TryParse(isbn, out _)))
                Console.WriteLine("ISBN must be numeric and contain 13 digits.");
        } while (!(!string.IsNullOrWhiteSpace(isbn) && isbn.Length == 13 && long.TryParse(isbn, out _)));
        
        int currentYear = DateTime.Now.Year;
        do
        {
            Console.WriteLine("Enter book publish date: ");
            year = Convert.ToInt32(Console.ReadLine());
            if (year < 1500 || year > currentYear)
                Console.WriteLine($"Publishing year must be between 1500 and {currentYear}.");
        } while (year < 1500 || year > currentYear);
        
        BookModel book = new BookModel(id, title, author, isbn, year);
        books.Add(book);
    }

    public List<BookModel?> GetBooks()
    {
        return books;
    }

    public BookModel? GetBookById(int id)
    {
        return books.FirstOrDefault(livro => livro.Id == id);
    }

    public void DeleteBook(int bookId)
    {
        var book = books.FirstOrDefault(livro => livro.Id == bookId);
        books.Remove(book);
    }
}