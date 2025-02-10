namespace LibraryManager.API.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserModel(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}