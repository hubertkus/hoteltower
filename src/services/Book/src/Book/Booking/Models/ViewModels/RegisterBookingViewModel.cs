using System.ComponentModel.DataAnnotations;
namespace Booking.Models.ViewModels;

public class RegisterBookingViewModel
{
    [Required(ErrorMessage = "Id użytkownika jest wymagany")]
    public Guid UserId { get; set; } = Guid.Empty;
    [Required(ErrorMessage = "Id pokoju jest wymagane")]
    public Guid RoomId { get; set; } = Guid.Empty;
    [Required(ErrorMessage = "Data rozpoczęcia jest wymagana")]
    public DateOnly From { get; set; } = DateOnly.MinValue;
    [Required(ErrorMessage = "Data zakończenia jest wymagana")]
    public DateOnly To { get; set; } = DateOnly.MinValue;
}