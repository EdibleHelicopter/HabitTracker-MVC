using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

using System.IO;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {

        public string Name;
        HabitManager manager = new HabitManager();
         [HttpGet]
       public async Task Index()
        {
            string content = @"<form method='post'>
                <label>Name:</label><br />
                <input name='Name' /><br />
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            
            
            await Response.WriteAsync(content);
            
        }
        [HttpPost]
        public ActionResult Index(Habit habit)
        {
            manager.AddHabit(habit);
            return Content(Name);
        }
    }
}



