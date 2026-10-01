using User.ValueObjects;
namespace User.Models;

public class User
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Guid Id { get; init; }

    public User(Name name, Email email)
    {
        Name = name;
        Email = email;
    }
}