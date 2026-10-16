using System.ComponentModel.Design;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Room.Models;

namespace Book.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult SeedRooms()
    {
        var serviceProvider=HttpContext.RequestServices;
        SeedData.EnsurePopulated(serviceProvider,serviceProvider.GetRequiredService<IRoomRepository>());
        return Content("<h2 style='color: green;'>Dodano pokoje</h2>", "text/html; charset=utf-8");
    }

}