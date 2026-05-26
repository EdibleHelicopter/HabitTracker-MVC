using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class HabitController : Controller
{
    HabitManager habitManager = new HabitManager();
 
    public IActionResult Index()
    {
        int userId = (int)TempData.Peek("Id");
        habitManager.LoadHabits(userId);
        return View(habitManager.DeserializeHabitsFromFile());
    }

    [HttpPost]
    public IActionResult AddHabit(Habit habit)
    {
        int userId = (int)TempData.Peek("Id");
        habitManager.Serialize(habit);
        return RedirectToAction("Index");
    }
}



