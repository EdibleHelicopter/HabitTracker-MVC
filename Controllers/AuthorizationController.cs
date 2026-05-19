using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class AuthorizationController : Controller
{
    UserManager userManager = new UserManager();

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult AddUser(User user)
    {
        userManager.Serialize(user);
        return RedirectToAction("Index", "Home");
    }
}