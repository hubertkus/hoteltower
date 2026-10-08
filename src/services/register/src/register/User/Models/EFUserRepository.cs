using Microsoft.EntityFrameworkCore;
using Register.Data;
using User.Exceptions;
using User.ValueObjects;

namespace User.Models;

public class EFUserRepository : IUserRepository
{
    private readonly RegisterDbContext context;

    public EFUserRepository(RegisterDbContext _context)
    {
        context = _context;
    }
    public async Task<User?> GetByEmailAsync(Email Email, CancellationToken cancellationToken)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == Email, cancellationToken);
    }
    public async Task<User> AddUser(User User)
    {
        try
        {
            await context.AddAsync(User);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new RegisterUserFaultException(User.Name.Value, ex);
        }
        return User;
    }
}