
namespace User.Models;

public interface IUserRepository
{
    IQueryable<User> Users { get; }
    Task<User> AddUser(User user);
}