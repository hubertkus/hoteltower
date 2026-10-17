using Microsoft.AspNetCore.Mvc;
using Room.Models;
using Book.Data;
namespace Book.Controllers;

public class AdminController : Controller
{
    private readonly IRoomsSeeder roomsSeeder;
    public AdminController(IRoomsSeeder _roomsSeeder)
    {
        roomsSeeder = _roomsSeeder;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> SeedRooms()
    {
        var added = await roomsSeeder.EnsurePopulated();

        if (added==true)
           return Content("<h2 style='color: green;'>Dodano pokoje</h2>", "text/html; charset=utf-8");
        else
           return Content("<h2 style='color: green;'>Pokoje już istnieją</h2>", "text/html; charset=utf-8");
    }
}