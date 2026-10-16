using Microsoft.AspNetCore.Mvc;
using Room.Models;
using Book.Data;
namespace Book.Controllers;

public class AdminController : Controller
{
    private readonly IRoomRepository roomRepository;
    private readonly BookDbContext bookDbContext;

    public AdminController(IRoomRepository _roomRepository,BookDbContext _bookDbContext)
    {
        roomRepository=_roomRepository;
        bookDbContext=_bookDbContext;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> SeedRooms()
    {
        if(!await SeedData.EnsurePopulated(roomRepository,bookDbContext))
           return Content("<h2 style='color: green;'>Pokoje już istnieją</h2>", "text/html; charset=utf-8");

        return Content("<h2 style='color: green;'>Dodano pokoje</h2>", "text/html; charset=utf-8");
    }

}