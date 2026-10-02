using MediatR;
using User.ValueObjects;

namespace User.RegisterUser.Commands;

public record RegisterUserCommand(string Name, string Email) : IRequest<RegisterUserResult>
{ public Guid Id { get; init; } = Guid.NewGuid(); }