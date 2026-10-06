using System.Threading.Tasks.Dataflow;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Models;
using User.ValueObjects;
using User.RegisterUser.Commands;

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
        var name = Name.Of(command.Name);
        var email = Email.Of(command.Email);

        var entity = await _userRepository.GetByEmailAsync(email, cancellationToken);

        if (entity == null)
        {
            var user = new User.Models.User(name, email);
            entity = await _userRepository.AddUser(user);
        }
        return new RegisterUserResult() { Id = entity.Id };
    }
}