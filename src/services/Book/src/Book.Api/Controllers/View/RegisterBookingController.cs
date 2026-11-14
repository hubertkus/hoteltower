using Booking.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Register.Controllers;

public class RegisterBookingController : Controller
{
    private readonly HttpClient httpClient;
    public RegisterBookingController(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Booking");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
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