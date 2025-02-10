namespace LibraryManager.API.Models;

public class LibraryManager
{
    private List<BookModel?> books = new ();
    private List<UserModel?> users = new ();
        private List<Loan?> lendings = new ();

    public void AddBook()
    {
        string? title;
        string? author;
        string? isbn;
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
        } while (id <= 0 || books.Any(book => book.Id == id));
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

    public void LendBook(int Id)
    {
        GetBookById(Id).Islent = true;
    }

    public void DeleteBook(int bookId)
    {
        var book = books.FirstOrDefault(livro => livro.Id == bookId);
        books.Remove(book);
    }

    public void AddUser()
    {
        string? name, email;
        int id;
        do
        {
            Console.WriteLine("Enter user ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
                Console.WriteLine("Id must be greater than zero");
            if (users.Any(user => user.Id == id))
            {
                Console.WriteLine("Id must be unique.");
            }
        } while (id <= 0 || users.Any(user => user.Id == id));
        
        do
        {
            Console.WriteLine("Enter username: ");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                Console.WriteLine("Author must not be empty.");
        } while (string.IsNullOrWhiteSpace(name));
        do
        {
            Console.WriteLine("Enter user email: ");
            email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
                Console.WriteLine("Author must not be empty.");
            if (users.Any(user => user.Email == email))
            {
                Console.WriteLine("Email must be unique.");
            }
        } while (string.IsNullOrWhiteSpace(email) || users.Any(user => user.Email == email));
        
        UserModel user = new UserModel(id, name, email);
        users.Add(user);
    }

    public void AddLending()
    {
        int id, day, month, year;
        BookModel? book;
        UserModel? user;
        
        do
        {
            Console.WriteLine("Enter lending ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
                Console.WriteLine("Id must be greater than zero");
            if (lendings.Any(loan => loan.Id == id))
            {
                Console.WriteLine("Id must be unique.");
            }
        } while (id <= 0 || lendings.Any(loan => loan.Id == id));

        Console.WriteLine("Choose Book Id from list bellow: ");
        foreach (BookModel? b in books)
        {
            Console.WriteLine(b.ToString());
        }
        var bookId = Convert.ToInt32(Console.ReadLine());
        book = GetBookById(bookId);
        
        Console.WriteLine("Choose User Id from list bellow: ");
        foreach (UserModel? b in users)
        {
            Console.WriteLine(b.ToString());
        }
        var userId = Convert.ToInt32(Console.ReadLine());
        user = users.FirstOrDefault(user => user.Id == userId);
        
        Console.WriteLine("Enter devolution year");
        year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter devolution month");
        month = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter devolution day");
        day = Convert.ToInt32(Console.ReadLine());
        
        var devolutionDate = new DateTime(year, month, day, 23, 59, 59);
        
        LendBook(bookId);
        Loan loan = new Loan(id, book, user, devolutionDate);
        lendings.Add(loan);
    }

    public void ReturnBook()
    {
        var today = DateTime.Now;
        Console.WriteLine("Choose Book Id from list bellow: ");
        foreach (BookModel? b in books)
        {
            Console.WriteLine(b.ToString());
        }
        var bookId = Convert.ToInt32(Console.ReadLine());
        GetBookById(bookId).Islent = false;
        var lending = lendings.FirstOrDefault(loan => loan.Book.Id == bookId);
        var devolutionDate = lending.DevolutionDate;
        lendings.Remove(lending);

        if (today <= devolutionDate)
        {
            Console.WriteLine($"You are due to devolution in {(devolutionDate - today).Days} days.)");
            return;
        }
        Console.WriteLine($"You are {(devolutionDate - today).Days} days late to return the book.)");
    }
}