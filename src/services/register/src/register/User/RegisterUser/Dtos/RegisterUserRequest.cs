
namespace User.RegisterUser.Dtos;

public record RegisterUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}