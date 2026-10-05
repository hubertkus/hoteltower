using Microsoft.EntityFrameworkCore;
using Register.Data;
using User.Exceptions;
using User.ValueObjects;

namespace User.Models;

public class EFUserRepository : IUserRepository
{
    private readonly RegisterDbContext _context;

    public EFUserRepository(RegisterDbContext context)
    {
        _context = context;
    }
    public IQueryable<User> Users => _context.Users;

    public async Task<User> AddUser(User User)
    {
        var user = Users.FirstOrDefault(u => u.Email == User.Email);
        try
        {
            if (user == null)
            {
                user = (await _context.AddAsync(User)).Entity;
            }
            await _context.SaveChangesAsync();
        }
        catch (RegisterUserFaultException ex)
        {
            throw new RegisterUserFaultException(User.Name.Value, ex);
        }
        return user;
    }
}