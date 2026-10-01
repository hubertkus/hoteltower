using System.Threading.Tasks.Dataflow;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<RegisterUserResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.Users.FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (entity == null)
        {
            var user = command.Adapt<User.Models.User>();
            entity = await _userRepository.AddUser(user);
        }
        return new RegisterUserResult() { Id = entity.Id };
    }
}