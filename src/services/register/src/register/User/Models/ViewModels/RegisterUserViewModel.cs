using System.ComponentModel.DataAnnotations;
namespace User.Models.ViewModels;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email jest wymagany")]
    [EmailAddress(ErrorMessage = "Podaj poprawny adres email")]
    public string Email { get; set; } = string.Empty;
}