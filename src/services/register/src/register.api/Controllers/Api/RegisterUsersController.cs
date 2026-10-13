using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.RegisterUser.Commands;
using User.RegisterUser.Dtos;
using Mapster;

namespace Register.Controllers;

[ApiController]
[Route("register/user")]
public class RegisterUsersController : ControllerBase
{
    private readonly IMediator mediator;

    public RegisterUsersController(IMediator _mediator)
    {
        mediator = _mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUsers(RegisterUserRequest request)
    {
        var command = request.Adapt<RegisterUserCommand>();

        var result = await mediator.Send(command);

        return Ok(result);
    }
}