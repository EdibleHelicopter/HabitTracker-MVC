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
        return View(habitManager.DeserializeHabitsFromFile());
    }

    [HttpPost]
    public IActionResult AddHabit(Habit habit)
    {
        
        habitManager.Serialize(habit);
        return RedirectToAction("Index");
    }
}



