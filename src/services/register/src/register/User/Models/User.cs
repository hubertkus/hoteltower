using User.ValueObjects;
namespace User.Models;

public class User
{
    public required Name Name { get; set; }
    public required Email Email { get; init; }
    public Guid Id { get; init; }
}