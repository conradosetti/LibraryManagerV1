namespace LibraryManager.API.Models;

public class Loan
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public BookModel Book { get; set; }
    public UserModel User { get; set; }
    public DateTime DevolutionDate { get; set; }

    public Loan(int id, BookModel book, UserModel user, DateTime devolutionDate)
    {
        Id = id;
        Book = book;
        User = user;
        DevolutionDate = devolutionDate;
    }
}