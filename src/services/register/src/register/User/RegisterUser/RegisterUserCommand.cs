using MediatR;
using User.ValueObjects;

namespace User.RegisterUser;

public record RegisterUserCommand(Name Name, Email Email) : IRequest<RegisterUserResult>
{ public Guid Id { get; init; } = Guid.NewGuid(); }