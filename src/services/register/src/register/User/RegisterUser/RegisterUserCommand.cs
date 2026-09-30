using MediatR;

namespace User.RegisterUser;

public record RegisterUserCommand(string Name, string Email) : IRequest<CreateUserResult>
{ }