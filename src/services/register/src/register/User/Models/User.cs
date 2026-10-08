using User.ValueObjects;
namespace User.Models;

public class User
{
    public Name Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Guid Id { get; init; }

    public User(Name name, Email email)
    {
        Name = name;
        Email = email;
    }
    private User()
    { }
}