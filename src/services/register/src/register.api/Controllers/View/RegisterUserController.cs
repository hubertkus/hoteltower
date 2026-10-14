using User.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Register.Controllers;

public class RegisterUserController : Controller
{
    private readonly HttpClient httpClient;
    public RegisterUserController(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Register");
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await httpClient.PostAsJsonAsync("register/user", model);

        if (!response.IsSuccessStatusCode)
            return View(model);

        return Content("<h2 style='color: green;'>Zarejestrowano pomyślnie</h2>","text/html; charset=utf-8");
    }
}