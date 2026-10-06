using User.ValueObjects;

namespace User.Models;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);
    Task<User> AddUser(User user);
}