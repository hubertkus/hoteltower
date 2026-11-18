using Booking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using User.RegisterUser.Dtos;
using Room.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Register.Controllers;

public class RegisterBookingController : Controller
{
    private readonly HttpClient httpClient;
    private readonly IRoomRepository roomRepository;
    public RegisterBookingController(IHttpClientFactory httpClientFactory, IRoomRepository roomRepositoryFactory)
    {
        httpClient = httpClientFactory.CreateClient("Booking");
        roomRepository = roomRepositoryFactory;
    }

    [HttpGet]
    public IActionResult Index(RegisterUserResponse model)
    {

        var rooms = roomRepository.GetRooms();
        return View(new RegisterBookingViewModel
        {
            UserId = model.Id,
            Rooms = rooms.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            })
        });
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterBookingViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await httpClient.PostAsJsonAsync("register/booking", model);

        if (!response.IsSuccessStatusCode)
            return View(model);

        return Content("<h2 style='color: green;'>Pokój zarejestrowano pomyślnie</h2>","text/html; charset=utf-8");
    }
}