using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
 
namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {

        HabitManager manager = new HabitManager();
        [HttpGet]
        public ActionResult Index()
    {
        string html = @"
            <html>
            <head><title>Простая форма</title></head>
            <body>
                <h2>Введите значение:</h2>
                <form method='post' action='/Home/Index'>
                    <input type='text' name='Value' placeholder='Введите текст' />
                    <button type='submit'>Отправить</button>
                </form>
            </body>
            </html>";

        return Content(html, "text/html");
    }  
        [HttpPost]
         public ActionResult Index(string Value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            Value = "Пустое или некорректное значение";
        }

        string html = $@"
            <html>
            <head><title>Результат</title></head>
            <body>
                <h2>Вы ввели:</h2>
                <p><strong>{Value}</strong></p>
                <a href='/Home/Index'>Вернуться к форме</a>
            </body>
            </html>";
        return Content(html, "text/html");
    }
}
    }
