using User.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Register.Controllers;

public class RegisterUserController : Controller
{
 private readonly HttpClient httpClient;
 public RegisterUserController(HttpClient _httpClient)
 {
  httpClient = _httpClient;
 }

 [HttpPost]
 public async Task<IActionResult> Create(RegisterUserViewModel model)
 {
  if (!ModelState.IsValid)
   return View(model);

  var response = await httpClient.PostAsJsonAsync("register/user", model);

  if (!response.IsSuccessStatusCode)
   return View(model);

  return RedirectToAction("Index");
 }
}