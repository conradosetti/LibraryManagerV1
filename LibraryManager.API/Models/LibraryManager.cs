namespace LibraryManager.API.Models;

public class LibraryManager
{
    private List<BookModel?> books = new ();

    public void AddBook(int bookId, string title, string author, string isbn, int year)
    {
        BookModel book = new BookModel(bookId, title, author, isbn, year);
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