using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class HabitController : Controller
{
    HabitManager manager = new HabitManager();



    public IActionResult Index(Habit habit)
    {
        manager.Deserialize();
        return View(manager.habitList);
    }
    

    
        [HttpPost]
        public IActionResult AddHabit(Habit habit)
        {
            manager.AddHabit(habit);
            manager.Serialize(habit);
            foreach(Habit _habit in manager.habitList)
            {
                Console.WriteLine(_habit.Name);
            }
            return View(manager.habitList);
            return RedirectToAction("Index");
        }
        
}



