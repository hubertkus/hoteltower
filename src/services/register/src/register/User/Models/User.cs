namespace User.Models;

public class User
{
    public required string Name { get; init; }
    public required string Email { get; init; }

    public User(string name)
    {
        Name = name;
    }
}