using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booking.RegisterBooking.Commands;
using Booking.RegisterBooking.Queries;
using Mapster;

namespace Book.Controllers;

[ApiController]
[Route("register/booking")]
public class RegisterBookingsController : ControllerBase
{
    private readonly IMediator mediator;

    public RegisterBookingsController(IMediator _mediator)
    {
        mediator = _mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterBookings(RegisterBookingRequest request)
    {
        var command = request.Adapt<RegisterBookingCommand>();

        var result = await mediator.Send(command);

        return Ok(result);
    }
}