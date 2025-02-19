namespace LibraryManager.API.Models;

public class BookModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string? ISBN { get; private set; }
    public int Year { get; private set; }
    public bool Islent { get; set; } = false;

    public BookModel(int id, string? title, string? author, string? isbn, int year)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
    }
    
    public override string ToString()
    {
        var text = Islent ? "Book lent." : "Book unlent.";
        return $"[{Id}] {Title} - {Author} ({Year}) - ISBN: {ISBN} - ";
    }
}